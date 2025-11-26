using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootRange = 10f;

    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] public float BuffTime;
    [SerializeField] public float TempFireRate;
    [SerializeField] public float OriginalFireRate;


    //line of sight variables
    public float _sightRange = 10f;
    public float _fieldOfView = 90f;
    public LayerMask _obstacleLayer;

    public bool _targetInSight = false;

    public float fireRate = 1f;
    private float fireCooldown = 0f;

    private Transform target;

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        // get the closest enemy within range
        GameObject targetObj = FindClosestEnemyInRange();

        if (targetObj != null)
        {
            target = targetObj.transform;
        }
        if (targetObj != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget <= shootRange)
            {
                IsTargetVisible();
                if (fireCooldown <= 0f && _targetInSight)
                {
                    ShootAt(targetObj);
                    fireCooldown = 1f / fireRate;
                }

            }
        }
    }
    public void _startAmmoBuff()
    {
        StartCoroutine(AmmoiItemBuff());
    }
    IEnumerator AmmoiItemBuff()
    {
        OriginalFireRate = fireRate;
        fireRate = TempFireRate;
        yield return new WaitForSeconds(BuffTime);
        fireRate = OriginalFireRate;
        Debug.Log("powerup over");
    }
    GameObject FindClosestEnemyInRange()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= shootRange && distance < minDistance)
            {
                closest = enemy;
                minDistance = distance;
            }
        }

        return closest;
    }


    public bool IsTargetVisible()
    {
        if (target == null) return false;

        float distanceTo_target = Vector3.Distance(transform.position, target.position);

        // Check if target is within sight range
        if (distanceTo_target > _sightRange)
        {
            _targetInSight = false;
            return false;
        }

        // Check if target is within field of view
        Vector3 directionTo_target = (target.position - transform.position).normalized;
        float angleTo_player = Vector3.Angle(transform.forward, directionTo_target);

        if (angleTo_player > _fieldOfView / 2)
        {
            _targetInSight = false;
            return false;
        }

        // Check for obstacles
        if (Physics.Raycast(transform.position, directionTo_target, distanceTo_target, _obstacleLayer))
        {
            _targetInSight = false;
            return false;
        }
        else
        {
            _targetInSight = true;
            return true;
        }
    }
    void ShootAt(GameObject enemy)
    {
        if (projectilePrefab == null || firePoint == null) return;

        // direction to target
        Vector3 direction = (enemy.transform.position - firePoint.position).normalized;

        // create the projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * projectileSpeed;
        }
    }

}
