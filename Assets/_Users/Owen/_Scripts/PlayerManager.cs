using UnityEngine;
using UnityEngine.AI;

public class PlayerManager : MonoBehaviour //this is currently ONLY MOVE SPEED
{
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        NavMeshAgent playerAgent = player.GetComponent<NavMeshAgent>();
        playerAgent.speed = PlayerData.Instance._moveSpeed;
    }

  
}
