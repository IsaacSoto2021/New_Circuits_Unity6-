using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserTrap : MonoBehaviour
{
    [Header("Laser Settings")]
    public GameObject laserObject;     // The child laser visual + trigger collider
    public float toggleInterval = 2f;  // Seconds between on/off
    public int damageAmount = 10;      // Damage dealt to player

    private bool laserActive = false;

    [SerializeField] private AudioSource _audioSource;

    void Start()
    {
        if (laserObject == null)
        {
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
            _audioSource.Play();
            PlayerData.Instance._Hp -= damageAmount;
            PlayerData.Instance._Hp = Mathf.Max(PlayerData.Instance._Hp, 0);
        }

        if (PlayerData.Instance._Hp <= 0)
        {
            SceneManager.LoadScene(0);
            PlayerData.Instance.LoseTempResources();
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
