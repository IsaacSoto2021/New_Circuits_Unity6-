using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.Rendering.DebugUI;

public class Crypto : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            int _value = Random.Range(4, 12);
            PlayerData.Instance._scrapToAdd += _value;
            Debug.Log("Crypto picked up: " + _value);
            Destroy(gameObject);
        }
    }
}
