using UnityEngine;

public class KeycardPickup : MonoBehaviour
{
    public bool red;
    public bool green;
    public bool blue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Keycard"))
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
