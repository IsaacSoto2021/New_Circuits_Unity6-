using UnityEngine;
using TMPro;

public class SkillTreeUIManager1 : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI currencyText; // Assign in Inspector

    private PlayerData player;

    void Start()
    {
        // Grab the PlayerData singleton
        player = PlayerData.Instance;

        if (currencyText == null)
        {
            Debug.LogError("SkillTreeUIManager: No TextMeshProUGUI component assigned!");
        }
    }

    void Update()
    {
        if (player == null || currencyText == null)
            return;

        // Display current currencies with multiple lines
        currencyText.text =
            $"Scrap: {player._scrap}\n" +
            $"Crypto: {player._crypto}\n" +
            $"Electronics: {player._electronics}";
    }
}
