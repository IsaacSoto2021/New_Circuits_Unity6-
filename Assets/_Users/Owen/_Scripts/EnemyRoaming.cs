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

    public Transform _centrePoint; //centre of the area the agent wants to move around in

    public Transform _player;

    public bool _playerInSight;
    bool _roaming = false;
    bool _chasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Awake()
    {
        _roaming = true;
        _chasing = false;
        _player = PlayerData.Instance.transform;
    }

    void Update()
    {
        _distance = Vector3.Distance(this.transform.position, _player.position);
        if (_distance < _chaseRange)
        {
            _chasing = true;
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


}
