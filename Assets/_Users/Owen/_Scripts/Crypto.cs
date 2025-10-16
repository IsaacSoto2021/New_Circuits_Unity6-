using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Crypto : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerData.Instance._scrapToAdd += Random.Range(4, 12);
            Destroy(gameObject);
        }
    }
}
