using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPSystemLv2 : MonoBehaviour
{
    public int _HP = 150;

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
        if (_HP <= 0)
        {
            ActivateRandomTimes();
            PlayerData.Instance._kills++;
            Destroy(gameObject);
        }
    }

    private void ActivateRandomTimes()
    {
        int times = Random.Range(0, 5);

        for (int i = 0; i < times; i++)
        {
            PlayerData.Instance._scrapToAdd++;
        }
    }
}
