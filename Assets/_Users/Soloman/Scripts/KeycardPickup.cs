using UnityEngine;

public class KeycardPickup : MonoBehaviour
{
    public bool red;
    public bool green;
    public bool blue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (red)
            {
                PlayerData.Instance._hasKeycardRed = true;
                Destroy(gameObject);
            }
            else if (green)
            {
                PlayerData.Instance._hasKeycardGreen = true;
                Destroy(gameObject);
            }
            else if (blue)
            {
                PlayerData.Instance._hasKeycardBlue = true;
                Destroy(gameObject);
            }
        }
    }
}
