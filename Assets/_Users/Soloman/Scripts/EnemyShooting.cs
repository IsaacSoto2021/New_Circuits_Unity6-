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

    public float _sightRange = 10f;
    public float _fieldOfView = 90f;
    public LayerMask _obstacleLayer;

    public bool _playerInSight = false;

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
            Debug.Log("player seen");
            return true;
        }
    }
    void ShootAtPlayer()
    {
        if (projectilePrefab == null || firePoint == null) return;

        Vector3 direction = (player.position - firePoint.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * projectileSpeed;
        }
    }

}
