using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    bool _unOpened = true;
    public GameObject _ScrapPrefab;
    public GameObject _ElectronicPrefab;
    public GameObject _CryptoPrefab;
    public Transform _SpawnPos1;
    public Transform _SpawnPos2;
    public Transform _SpawnPos3;
    public Transform _SpawnPos4;
    private void Start()
    {
        _unOpened = true;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && _unOpened)
        {
            GameObject Scrap1 = Instantiate(_ElectronicPrefab, _SpawnPos1);
            GameObject Scrap2 = Instantiate(_ElectronicPrefab, _SpawnPos2);
            ScrapChance();
            CryptoChance();
            _unOpened = false;
        }
    }
    private void ScrapChance()
    {
        int spawnChance = Random.Range(1, 2);
        if (spawnChance == 1)
        {
            GameObject Scrap3 = Instantiate(_ScrapPrefab, _SpawnPos3);
            Debug.Log("scrap");
        }
    }
    private void CryptoChance()
    {
        int spawnChance = Random.Range(1, 3);
        if (spawnChance == 1)
        {
            GameObject Scrap4 = Instantiate(_CryptoPrefab, _SpawnPos4);
            Debug.Log("crpy");

        }
    }

}
