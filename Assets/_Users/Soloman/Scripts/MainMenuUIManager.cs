using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuUIManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI cryptoText;   // Shows only the crypto number
    public Button playButton;            // Play button
    public Button upgradesButton;        // Upgrades button

    private PlayerData player;

    void Start()
    {
        // Grab PlayerData singleton
        player = PlayerData.Instance;

        if (cryptoText == null) Debug.LogError("MainMenuUIManager: No cryptoText assigned!");
        if (playButton == null) Debug.LogError("MainMenuUIManager: No playButton assigned!");
        if (upgradesButton == null) Debug.LogError("MainMenuUIManager: No upgradesButton assigned!");

        // Hook up buttons
        playButton.onClick.AddListener(OnPlayButtonPressed);
        upgradesButton.onClick.AddListener(OnUpgradesButtonPressed);
    }

    void Update()
    {
        if (player == null || cryptoText == null) return;

        // Update TMP text with only the crypto number
        cryptoText.text = player._crypto.ToString();
    }

    public void OnPlayButtonPressed()
    {
        GameManager.Instance.Play();
        Debug.LogError("failed");
    }

    public void OnUpgradesButtonPressed()
    {
        GameManager.Instance.GameScene();
        Debug.LogError("failed");
    }
}
