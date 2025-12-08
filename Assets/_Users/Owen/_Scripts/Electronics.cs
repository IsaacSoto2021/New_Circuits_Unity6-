using UnityEngine;

public class Electronics : MonoBehaviour
{
    [SerializeField] private int _value;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerData.Instance._electronicsToAdd += _value;
            Debug.Log("Electronics picked up: " + _value);
            Destroy(gameObject);
        }
    }
}
