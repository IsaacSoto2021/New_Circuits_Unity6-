using System.Collections;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    [Header("Laser Settings")]
    public GameObject laserObject;     // The child laser visual + trigger collider
    public float toggleInterval = 2f;  // Seconds between on/off
    public int damageAmount = 10;      // Damage dealt to player

    private bool laserActive = false;

    void Start()
    {
        if (laserObject == null)
        {
            Debug.LogError("LaserTrap: No laserObject assigned!");
            return;
        }

        // Ensure child collider forwards trigger events to this parent
        LaserChildTrigger trigger = laserObject.GetComponent<LaserChildTrigger>();
        if (trigger == null)
        {
            trigger = laserObject.AddComponent<LaserChildTrigger>();
        }
        trigger.parentTrap = this;

        // Start toggling the laser on/off
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

    // Called by the child trigger when something enters
    public void HandleTriggerEnter(Collider other)
    {
        if (!laserActive) return;

        if (other.CompareTag("Player"))
        {
            PlayerData.Instance._Hp -= damageAmount;
            PlayerData.Instance._Hp = Mathf.Max(PlayerData.Instance._Hp, 0);
            Debug.Log($"Laser hit player! -{damageAmount} HP | Current HP: {PlayerData.Instance._Hp}");
        }
    }
}

// forwards trigger events to the parent LaserTrap
public class LaserChildTrigger : MonoBehaviour
{
    [HideInInspector] public LaserTrap parentTrap;

    private void OnTriggerEnter(Collider other)
    {
        if (parentTrap != null)
        {
            parentTrap.HandleTriggerEnter(other);
        }
    }
}
