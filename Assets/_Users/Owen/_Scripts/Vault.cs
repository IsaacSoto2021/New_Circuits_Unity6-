using UnityEngine;
using System.Collections;


public class Vault : MonoBehaviour
{
    bool _unOpened = true;

    public GameObject _Item1;
    public GameObject _Item2;
    public GameObject _Item3;
    public GameObject _Item4;
    public GameObject _Item5;

    public Transform _SpawnPos1;
    public Transform _SpawnPos2;
    public Transform _SpawnPos3;
    public Transform _SpawnPos4;
    public Transform _SpawnPos5;

    [SerializeField] private AudioSource _ChestOpenSFX;
    [SerializeField] private AudioSource _ChestLureSFX;
    [SerializeField] private Animator _ChestAnimator;
    [SerializeField] private ParticleSystem _ParticleSystem;

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
        _ChestOpenSFX.Play();
        _ParticleSystem.Stop();

        yield return new WaitForSeconds(3f);


        SpawnItem1();
        SpawnItem2();
        SpawnItem3();
        SpawnItem4();
        SpawnItem5();
    }
    private void SpawnItem1()
    {
        if (_SpawnPos1 != null && _Item1 != null)
        {
            int spawnChance = Random.Range(1, 10);
            if (spawnChance <= 10)
            {
                GameObject Item1 = Instantiate(_Item1, _SpawnPos1);
                Debug.Log("Item 1");
            }
            spawnChance = 0;
        }
    }
    private void SpawnItem2()
    {
        if (_SpawnPos2 != null && _Item2 != null)
        {
            int spawnChance = Random.Range(1, 10);
            if (spawnChance <= 10)
            {
                GameObject Item2 = Instantiate(_Item2, _SpawnPos2);
                Debug.Log("Item 2");
            }
            spawnChance = 0;

        }
    }

    private void SpawnItem3()
    {
        if (_SpawnPos3 != null && _Item3 != null)
        {
            int spawnChance = Random.Range(1, 10);
            if (spawnChance <= 10)
            {
                GameObject Item3 = Instantiate(_Item3, _SpawnPos3);
                Debug.Log("Item 3");
            }
            spawnChance = 0;

        }
    }
    private void SpawnItem4()
    {
        if (_SpawnPos4 != null && _Item4 != null)
        {
            int spawnChance = Random.Range(1, 10);
            if (spawnChance <= 10)
            {
                GameObject Item4 = Instantiate(_Item4, _SpawnPos4);
                Debug.Log("Item 4");

            }
            spawnChance = 0;

        }
    }
    private void SpawnItem5()
    {
        if (_SpawnPos5 != null && _Item5 != null)
        {
            int spawnChance = Random.Range(1, 10);
            if (spawnChance <= 10)
            {
                GameObject Item5 = Instantiate(_Item5, _SpawnPos5);
                Debug.Log("Item 5");

            }
            spawnChance = 0;

        }
    }
}