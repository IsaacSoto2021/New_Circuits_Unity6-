using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHPSystem : MonoBehaviour
{
    [SerializeField] public int _HP;
    [SerializeField] private RandomMovement _EnemyRoaming;
    [SerializeField] private Transform DropLocation;
    [SerializeField] private Transform Dropheight;
    [SerializeField] private bool KeycardDrop;
    [SerializeField] private GameObject Keycard;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("PlayerProjectile"))
        {
            TakeDamage();
        }

    }
    public void TakeDamage()
    {
        _HP -= PlayerData.Instance._damage;
        StartCoroutine(LOSBuffOnDamage());
        if (_HP <= 0)
        {
            if (KeycardDrop)
            {
                DropKeyCard();
            }
            PlayerData.Instance._kills++;
            Destroy(gameObject);
        }
    }

    IEnumerator LOSBuffOnDamage()
    {
        _EnemyRoaming._fieldOfView = 360f;
        yield return new WaitForSeconds(1.5f);
        _EnemyRoaming._fieldOfView = 110f;
    }

    public void DropKeyCard()
    {
        Vector3 dropPos = DropLocation.position;
        dropPos.y = Dropheight.position.y;
        GameObject newKeyCard = Instantiate(Keycard, dropPos, Quaternion.identity);
    }
    private void ActivateRandomTimes()
    {
        int times = Random.Range(0, 5);

        for (int i = 0; i < times; i++)
        {
            PlayerData.Instance._scrapToAdd++;//replace loot type
        }
    }
}
