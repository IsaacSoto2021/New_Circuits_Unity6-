using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.Rendering.DebugUI;

public class Crypto : MonoBehaviour
{
    [SerializeField] private int value;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerData.Instance._cryptoToAdd += value;
            Destroy(gameObject);
        }
    }
}
