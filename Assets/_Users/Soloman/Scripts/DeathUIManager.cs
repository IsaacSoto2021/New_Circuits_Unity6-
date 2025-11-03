using UnityEngine;
using TMPro;

public class DeathUIManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI deathUIText; // Assign your TMP text object in the Inspector

    private PlayerData player;

    void Start()
    {
        // Grab the PlayerData singleton
        player = PlayerData.Instance;

        if (deathUIText == null)
        {
            Debug.LogError("DeathUIManager: No TextMeshProUGUI component assigned!");
        }
    }

    void Update()
    {
        if (player == null || deathUIText == null)
            return;

        // Update the UI text with multiple lines
        deathUIText.text =
            $"Scrap Collected: {player._scrapToAdd}\n" +
            $"Crypto Collected: {player._cryptoToAdd}\n" +
            $"Electronics Collected: {player._electronicsToAdd}";
    }
}
