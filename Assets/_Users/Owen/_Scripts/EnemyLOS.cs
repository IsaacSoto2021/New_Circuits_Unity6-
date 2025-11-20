using UnityEngine;
using UnityEngine.AI;

public class EnemyLOS : MonoBehaviour
{
    public float _sightRange = 10f;
    public float _fieldOfView = 90f;
    public LayerMask _obstacleLayer;

    private Transform _player;
    private NavMeshAgent _agent;
    private bool _playerInSight = false;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("_player").transform;
    }
    public bool Is_playerVisible()
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

        _playerInSight = true;
        return true;
    }

    public void Face_player()
    {
        if (_player != null && _playerInSight)
        {
            Vector3 direction = (_player.position - transform.position).normalized;
            direction.y = 0; // Keep upright
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            }
        }
    }
    // Visual debugging
    void OnDrawGizmosSelected()
    {
        // Draw sight range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _sightRange);

        // Draw field of view
        Vector3 leftBoundary = Quaternion.Euler(0, _fieldOfView / 2, 0) * transform.forward * _sightRange;
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
