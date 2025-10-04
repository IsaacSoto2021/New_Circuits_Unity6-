using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            return;
        }
        else
        {
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
