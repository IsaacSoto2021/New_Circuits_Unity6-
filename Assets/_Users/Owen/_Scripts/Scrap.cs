using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour
{
    [SerializeField] private int _value;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerData.Instance._scrapToAdd += _value;
            Debug.Log("Loot picked up: " + _value);
            Destroy(gameObject);
        }
    }
}
