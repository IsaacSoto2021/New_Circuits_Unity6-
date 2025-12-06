using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootRange = 10f;
    public float fireRate = 1f;
    [SerializeField] float projectileSpeed = 8f;

    //line of sight variables
    public float _sightRange = 10f;
    public float _fieldOfView = 90f;
    public LayerMask _obstacleLayer;

    public bool _playerInSight = false;

    //Variables for shot randomness
    [SerializeField] float maxShotRandomness = 0f; //Maximum angle in degrees
    [SerializeField] bool useRandomness = true;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _gunshotClip;


    private float fireCooldown = 0f;
    private Transform player;

    void Start()
    {
        // Find the player by tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        _audioSource.clip = _gunshotClip;
    }

    void Update()
    {
        if (player == null) return;

        fireCooldown -= Time.deltaTime;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= shootRange)
        {
            IsPlayerVisible();
            if (fireCooldown <= 0f && _playerInSight)
            {
                ShootAtPlayer();
                fireCooldown = 1f / fireRate;
            }
        }

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
        _audioSource.pitch = (Random.Range(1f, 1.12f));
        _audioSource.Play();

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * projectileSpeed;
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

}
