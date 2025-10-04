using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtractionZone : MonoBehaviour
{
    public float requiredTimeInZone = 5f;

    private float timer = 0f;
    private bool playerInside = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            timer = 0f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            timer = 0f;
        }
    }

    void Update()
    {
        if (playerInside)
        {
            timer += Time.deltaTime;

            if (timer >= requiredTimeInZone)
            {
                Debug.Log("Player extracted!");
                PlayerData.Instance.GainTempScrap();
                SceneManager.LoadScene(0);
            }
        }
    }

}
