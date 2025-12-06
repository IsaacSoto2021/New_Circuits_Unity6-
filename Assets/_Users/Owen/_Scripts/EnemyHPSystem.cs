using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPSystem : MonoBehaviour
{
    [SerializeField] public int _HP;
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
            PlayerData.Instance._kills++;
            Destroy(gameObject);
        }
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
