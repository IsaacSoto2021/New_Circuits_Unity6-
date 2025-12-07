using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootRange = 10f;
    public float fireRate = 1f;
    [SerializeField] float projectileSpeed = 8f;

    // Line of sight variables
    public float _sightRange = 10f;
    public float _fieldOfView = 90f;
    public LayerMask _obstacleLayer;
    public bool _playerInSight = false;

    // Variables for shot randomness
    [SerializeField] float maxShotRandomness = 0f;
    [SerializeField] bool useRandomness = true;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _gunshotClip;

    // Animation referencesreferences
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private bool isAnimated = true;

    [Header("Animation Settings")]
    [SerializeField] private string forwardParam = "Forward/Back";
    [SerializeField] private string horizontalParam = "Left/Right";
    [SerializeField] private string aimingParam = "Aiming";
    [SerializeField] private float animationSmoothTime = 0.1f;
    [SerializeField] private float aimTransitionSpeed = 5f;

    private float fireCooldown = 0f;
    private Transform player;

    // Animation variables
    private float currentForwardVelocity = 0f;
    private float currentHorizontalVelocity = 0f;
    private float currentAimWeight = 0f;
    private float targetAimWeight = 0f;
    private Vector3 previousPosition;

    void Start()
    {
        // Find the player by tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        _audioSource.clip = _gunshotClip;

        // Get components if not set
        if (navAgent == null) navAgent = GetComponent<NavMeshAgent>();
        if (enemyAnimator == null && isAnimated) enemyAnimator = GetComponent<Animator>();

        previousPosition = transform.position;
    }

    void Update()
    {
        if (player == null) return;

        fireCooldown -= Time.deltaTime;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if player is in sight range
        if (distanceToPlayer <= _sightRange)
        {
            IsPlayerVisible();

            targetAimWeight = _playerInSight ? .75f : 0f;
            currentAimWeight = Mathf.Lerp(currentAimWeight, targetAimWeight, Time.deltaTime * aimTransitionSpeed);

            UpdateMovementAnimation();

            if (distanceToPlayer <= shootRange && _playerInSight && fireCooldown <= 0f)
            {
                ShootAtPlayer();
                fireCooldown = 1f / fireRate;

                /*if (isAnimated && enemyAnimator != null)
                {
                    enemyAnimator.SetTrigger("Shoot");
                }*/
            }
        }
        else
        {
            _playerInSight = false;
            targetAimWeight = 0f;
            UpdateMovementAnimation();
        }

        if (isAnimated && enemyAnimator != null)
        {
            enemyAnimator.SetFloat(aimingParam, currentAimWeight);
        }
    }

    void UpdateMovementAnimation()
    {
        if (!isAnimated || enemyAnimator == null || navAgent == null) return;

        Vector3 currentPosition = transform.position;
        Vector3 velocity = (currentPosition - previousPosition) / Time.deltaTime;
        previousPosition = currentPosition;

        Vector3 localVelocity = transform.InverseTransformDirection(velocity);

        float targetForwardVelocity = localVelocity.z / navAgent.speed;

        float targetHorizontalVelocity = localVelocity.x / navAgent.speed;

        float aimMultiplier = Mathf.Lerp(.75f, 0.5f, currentAimWeight);
        targetForwardVelocity *= aimMultiplier;
        targetHorizontalVelocity *= aimMultiplier;

        currentForwardVelocity = Mathf.Lerp(currentForwardVelocity, targetForwardVelocity, Time.deltaTime / animationSmoothTime);

        currentHorizontalVelocity = Mathf.Lerp(currentHorizontalVelocity, targetHorizontalVelocity, Time.deltaTime / animationSmoothTime);

        enemyAnimator.SetFloat(forwardParam, currentForwardVelocity);
        enemyAnimator.SetFloat(horizontalParam, currentHorizontalVelocity);
    }

    public bool IsPlayerVisible()
    {
        if (player == null) return false;

        float distanceTo_player = Vector3.Distance(transform.position, player.position);

        // Check if _player is within sight range
        if (distanceTo_player > _sightRange)
        {
            _playerInSight = false;
            return false;
        }

        // Check if _player is within field of view
        Vector3 directionTo_player = (player.position - transform.position).normalized;
        float angleTo_player = Vector3.Angle(transform.forward, directionTo_player);

        if (angleTo_player > _fieldOfView / 2)
        {
            _playerInSight = false;
            return false;
        }

        // Check for obstacles
        if (Physics.Raycast(transform.position, directionTo_player, distanceTo_player, _obstacleLayer))
        {
            _playerInSight = false;
            return false;
        }
        else
        {
            _playerInSight = true;
            return true;
        }
    }

    void ShootAtPlayer()
    {
        if (projectilePrefab == null || firePoint == null) return;

        Vector3 direction = (player.position - firePoint.position).normalized;

        // Apply randomness if enabled
        if (useRandomness && maxShotRandomness > 0)
        {
            direction = GetRandomizedDirection(direction);
        }

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(firePoint.eulerAngles.x + 90, firePoint.eulerAngles.y, firePoint.eulerAngles.z));

        _audioSource.pitch = Random.Range(1f, 1.12f);
        _audioSource.Play();

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * projectileSpeed;
        }
    }

    Vector3 GetRandomizedDirection(Vector3 originalDirection)
    {
        float horizontalRandomAngle = Random.Range(-maxShotRandomness, maxShotRandomness);
        float verticalRandomAngle = Random.Range(-maxShotRandomness, maxShotRandomness);

        Quaternion horizontalSpread = Quaternion.AngleAxis(horizontalRandomAngle, Vector3.up);
        Quaternion verticalSpread = Quaternion.AngleAxis(verticalRandomAngle, Vector3.right);

        Vector3 randomizedDirection = horizontalSpread * verticalSpread * originalDirection;

        return randomizedDirection.normalized;
    }
}