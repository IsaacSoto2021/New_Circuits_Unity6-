using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPSystem : MonoBehaviour
{
    [SerializeField] public int _HP;
    [SerializeField] private RandomMovement _EnemyRoaming;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("PlayerProjectile"))
        {
            TakeDamage();
        }

    }
    public void TakeDamage()
    {
        _HP -= PlayerData.Instance._damage;
        StartCoroutine(LOSBuffOnDamage());
        if (_HP <= 0)
        {
            PlayerData.Instance._kills++;
            Destroy(gameObject);
        }
    }
    IEnumerator LOSBuffOnDamage()
    {
        _EnemyRoaming._fieldOfView = 360;
        yield return new WaitForSeconds(1.5f);
        _EnemyRoaming._fieldOfView = 110;
    }

    private void ActivateRandomTimes()
    {
        int times = Random.Range(0, 5);

        for (int i = 0; i < times; i++)
        {
            PlayerData.Instance._scrapToAdd++;//replace loot type
        }
    }
}
