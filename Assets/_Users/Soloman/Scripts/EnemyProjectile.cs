using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyProjectile : MonoBehaviour
{
    public float lifetime = 5f;

    public int damage = 10;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy") || (collision.CompareTag("PlayerProjectile")))
        {
            return;
        }
        else if (collision.CompareTag("Player")) 
        {
            PlayerData.Instance._Hp -= damage;
            if (PlayerData.Instance._Hp <= 0)//Player death handled here
            {
                SceneManager.LoadScene(0);
                PlayerData.Instance.LoseTempResources();
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
