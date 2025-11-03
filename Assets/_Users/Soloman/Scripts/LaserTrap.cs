using System.Collections;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    [Header("Laser Settings")]
    public GameObject laserObject; // The child laser beam
    public int damageAmount = 10;
    public float toggleInterval = 2f; // seconds

    private bool laserActive = false;

    void Start()
    {
        if (laserObject == null)
        {
            Debug.LogError("LaserTrap: No laserObject assigned!");
            return;
        }

        // Start the on/off cycle
        StartCoroutine(ToggleLaser());
    }

    private IEnumerator ToggleLaser()
    {
        while (true)
        {
            laserActive = !laserActive;
            laserObject.SetActive(laserActive);
            yield return new WaitForSeconds(toggleInterval);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!laserActive) return;

        // Check if we hit the player
        if (other.CompareTag("Player"))
        {
            // Apply damage
            PlayerData.Instance._Hp -= damageAmount;

            // Prevent HP from dropping below 0
            PlayerData.Instance._Hp = Mathf.Max(PlayerData.Instance._Hp, 0);

            Debug.Log($"Laser hit player! HP: {PlayerData.Instance._Hp}");

            // cooldown so it doesn't damage every frame
            StartCoroutine(DamageCooldown(other));
        }
    }

    private IEnumerator DamageCooldown(Collider player)
    {
        // Disable collider temporarily to prevent instant re-hit
        Collider col = GetComponentInChildren<Collider>();
        if (col != null)
            col.enabled = false;

        yield return new WaitForSeconds(0.5f); // half-second delay before next hit

        if (col != null)
            col.enabled = true;
    }
}
