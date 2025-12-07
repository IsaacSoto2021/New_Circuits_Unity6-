using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private EnemyShooting enemyShooting;
    [SerializeField] private RandomMovement enemyMovement;

    [Header("Animation Settings")]
    [SerializeField] private bool isAnimated = true;
    [SerializeField] private string forwardParam = "Forward/Bacl";
    [SerializeField] private string horizontalParam = "Left/Right";
    [SerializeField] private string aimingParam = "Aiming";
    [SerializeField] private float aimTransitionSpeed = 5f;

    [Header("Movement Params")]
    [SerializeField] private float movementSpeedMultiplier = 1f;
    [SerializeField] private float aimingMovementMultiplier = 1f; // Slow down when aiming if need

    private float currentAimWeight = 0f;
    private float targetAimWeight = 0f;
    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = transform.position;

        // Get components if not set in inspector
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        if (enemyAnimator == null && isAnimated) enemyAnimator = GetComponent<Animator>();
        if (enemyShooting == null) enemyShooting = GetComponent<EnemyShooting>();
        if (enemyMovement == null) enemyMovement = GetComponent<RandomMovement>();
    }

    void Update()
    {
        if (!isAnimated) return;

        UpdateAiming();
        UpdateMovementAnimation();
    }

    void UpdateAiming()
    {
        bool shouldAim = enemyShooting != null && enemyShooting._playerInSight;

        targetAimWeight = shouldAim ? .75f : 0f;
        currentAimWeight = Mathf.Lerp(currentAimWeight, targetAimWeight,
                                     Time.deltaTime * aimTransitionSpeed);

        if (enemyAnimator != null)
        {
            enemyAnimator.SetFloat(aimingParam, currentAimWeight);
        }

        if (agent != null)
        {
            float speedMultiplier = Mathf.Lerp(movementSpeedMultiplier, aimingMovementMultiplier, currentAimWeight);
            agent.speed = agent.speed * speedMultiplier;
        }
    }

    void UpdateMovementAnimation()
    {
        if (enemyAnimator == null || agent == null) return;

        // Calculate velocity
        Vector3 currentPosition = transform.position;
        Vector3 velocity = (currentPosition - previousPosition) / Time.deltaTime;
        previousPosition = currentPosition;

        // Convert to local space
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);

        // Apply aiming movement reduction
        float speedMultiplier = Mathf.Lerp(1f, aimingMovementMultiplier, currentAimWeight);

        // Calculate movement parameters
        float forward = localVelocity.z / agent.speed * speedMultiplier;
        float horizontal = localVelocity.x / agent.speed * speedMultiplier;

        // Set animator parameters
        enemyAnimator.SetFloat(forwardParam, forward);
        enemyAnimator.SetFloat(horizontalParam, horizontal);
    }

    public bool IsAiming()
    {
        return currentAimWeight > 0.5f;
    }
}
