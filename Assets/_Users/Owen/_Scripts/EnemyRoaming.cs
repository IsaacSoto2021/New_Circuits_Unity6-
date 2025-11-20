using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float _range = 10; //radius of sphere
    public float _distance; //distance to player
    public float _chaseRange = 15; //radius of chase
    public float _sightRange = 10f;
    public float _fieldOfView = 90f;

    public LayerMask _obstacleLayer;

    public bool _playerInSight = false;

    public Transform _centrePoint; //centre of the area the agent wants to move around in
    private Transform _player; //what enemy chases

    bool _roaming = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Awake()
    {
        _roaming = true;
    }

    void Update()
    {
        _distance = Vector3.Distance(this.transform.position, _player.position);
        if (_distance < _chaseRange && _playerInSight == true)
        {
            _roaming = false;
            ChasePlayer();
        }

        if ((agent.remainingDistance <= agent.stoppingDistance) && _roaming) //done with path
        {
            Vector3 point;
            if (RandomPoint(_centrePoint.position, _range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                agent.SetDestination(point);
            }
        }
        if (_playerInSight == false)
        {
            IsPlayerVisible();
        }
        else if (_playerInSight == true)
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

        Vector3 randomPoint = center + Random.insideUnitSphere * _range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if _range is big
            //or add a for loop like in the documentation
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
            Debug.Log("player seen");
            return true;
        }
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
