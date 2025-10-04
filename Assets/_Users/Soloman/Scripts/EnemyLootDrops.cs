using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLootDrops : MonoBehaviour
{
    private Transform parentTransform;

    void Start()
    {
        parentTransform = transform.parent;
    }

    void Update()
    {
        // Check if the parent has been destroyed
        if (parentTransform == null)
        {
            ActivateRandomTimes();
            // Disable this script so it doesn’t keep checking
            enabled = false;
        }
    }

    private void ActivateRandomTimes()
    {
        int times = Random.Range(0, 5);

        for (int i = 0; i < times; i++)
        {
            AddScrap();
        }
    }

    private void AddScrap()
    {
        PlayerData.Instance._scrapToAdd++;
    }
}
