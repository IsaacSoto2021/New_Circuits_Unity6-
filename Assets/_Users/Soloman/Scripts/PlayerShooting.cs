using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootRange = 10f;
    public float fireRate = 1f;
    [SerializeField] float projectileSpeed = 10f;


    private float fireCooldown = 0f;

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        // get the closest enemy within range
        GameObject target = FindClosestEnemyInRange();

        if (target != null && fireCooldown <= 0f)
        {
            ShootAt(target);
            fireCooldown = 1f / fireRate;
        }
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
