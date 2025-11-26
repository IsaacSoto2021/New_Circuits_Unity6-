using UnityEngine;
using System.Collections;


public class AmmoItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("ammo picked up");
            PlayerShooting playerShooting = collision.gameObject.GetComponent<PlayerShooting>();
            if (playerShooting != null)
            {
                playerShooting._startAmmoBuff();
                Destroy(gameObject);
            }

        }
    }
}

