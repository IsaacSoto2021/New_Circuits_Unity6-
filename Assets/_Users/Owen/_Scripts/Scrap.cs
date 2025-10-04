using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour
{
    public int _value = 5;

    private void Awake()
    {
        _value = 5;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerData.Instance._scrapToAdd += _value;
            Destroy(gameObject);
        }
    }
}
