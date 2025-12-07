using UnityEngine;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float _range = 10; //radius of sphere
    public float _distance; //distance to player
    public float _chaseRange = 15; //radius of chase
    public float _sightRange = 10f;
    public float _fieldOfView = 110f;

    public LayerMask _obstacleLayer;
    public bool _playerInSight = false;

    public Transform _centerPoint;
    private Transform _player;

    private Vector3 previousPosition;
    private float currentForwardVelocity;
    private float currentHorizontalVelocity;

    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private bool isAnimated = false;
    [SerializeField] private float animationSmoothTime = 0.1f;


    bool _roaming = false;
    private EnemyShooting enemyShooting;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyShooting = GetComponent<EnemyShooting>(); // Get the shooting script
    }


    private void Awake()
    {
        _roaming = true;
    }

    void Update()
    {
        if (_player == null) return;

        _distance = Vector3.Distance(this.transform.position, _player.position);

        // Use the visibility check from EnemyShooting script if available
        if (enemyShooting != null)
        {
            _playerInSight = enemyShooting._playerInSight;
        }
        else
        {
            // Fallback to own visibility check
            if (!_playerInSight)
            {
                IsPlayerVisible();
            }
        }

        // Chase player if in sight and within chase range
        if (_distance < _chaseRange && _playerInSight)
        {
            _roaming = false;
            ChasePlayer();
        }
        else
        {
            _roaming = true;
        }

        // Roam if not chasing
        if (_roaming && (agent.remainingDistance <= agent.stoppingDistance))
        {
            Vector3 point;
            if (RandomPoint(_centerPoint.position, _range, out point))
            {
                agent.SetDestination(point);
            }
        }

        // Face player when in sight
        if (_playerInSight)
        {
            Face_player();
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(_player.position);
    }

    bool RandomPoint(Vector3 center, float _range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * _range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    public bool IsPlayerVisible()
    {
        if (_player == null) return false;

        float distanceTo_player = Vector3.Distance(transform.position, _player.position);

        // Check if _player is within sight range
        if (distanceTo_player > _sightRange)
        {
            _playerInSight = false;
            return false;
        }

        // Check if _player is within field of view
        Vector3 directionTo_player = (_player.position - transform.position).normalized;
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

    public void Face_player()
    {
        if (_player != null && _playerInSight)
        {
            Vector3 direction = (_player.position - transform.position).normalized; direction.y = 0; // Keep upright
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction); transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _sightRange);

        Vector3 leftBoundary = Quaternion.Euler(0, -_fieldOfView / 2, 0) * transform.forward * _sightRange;
        Vector3 rightBoundary = Quaternion.Euler(0, _fieldOfView / 2, 0) * transform.forward * _sightRange;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, leftBoundary);
        Gizmos.DrawRay(transform.position, rightBoundary);

        if (_playerInSight)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, _player.position);
        }
    }
}
