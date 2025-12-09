using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HealthItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerData.Instance._Hp += 50;
            Destroy(gameObject);

        }
    }
}
