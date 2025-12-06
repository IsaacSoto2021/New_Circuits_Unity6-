using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    bool _unOpened = true;

    public GameObject _ScrapPrefab;
    public GameObject _ElectronicPrefab;
    public GameObject _CryptoPrefab;
    public GameObject _HealPrefab;

    public Transform _SpawnPos1;
    public Transform _SpawnPos2;
    public Transform _SpawnPos3;
    public Transform _SpawnPos4;

    [SerializeField] private AudioSource _ChestOpenSFX;
    [SerializeField] private AudioSource _ChestLureSFX;
    [SerializeField] private Animator _ChestAnimator;

    private void Start()
    {
        _unOpened = true;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && _unOpened)
        {
            OpenChest();
        }
    }
    public void OpenChest()
    {
        StartCoroutine(OpenChestRoutine());
        _unOpened = false;
    }
    IEnumerator OpenChestRoutine()
    {
        _ChestLureSFX.loop = false;
        _ChestLureSFX.Stop();
        _ChestAnimator.SetTrigger("Open");

        yield return new WaitForSeconds(0.5f);
        _ChestOpenSFX.Play();
        yield return new WaitForSeconds(0.5f);

        GameObject Scrap1 = Instantiate(_ElectronicPrefab, _SpawnPos1);
        GameObject Scrap2 = Instantiate(_HealPrefab, _SpawnPos2);

        ScrapChance();
        CryptoChance();
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
            Debug.Log("crypto");

        }
    }

}
