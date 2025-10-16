using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour
{
    [SerializeField] int _value;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerData.Instance._scrapToAdd += _value;
            Debug.Log("Loot picked for: " + _value);
            Destroy(gameObject);
        }
    }
}
