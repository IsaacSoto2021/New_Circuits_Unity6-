using TMPro;
using UnityEngine;

public class StatsSceneUIManager : MonoBehaviour
{
    public TextMeshProUGUI cryptoText;
    public TextMeshProUGUI electronicsText;
    public TextMeshProUGUI scrapText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cryptoText.text = PlayerData.Instance._crypto.ToString();
        scrapText.text = PlayerData.Instance._scrap.ToString();
        electronicsText.text = PlayerData.Instance._electronics.ToString();
    }
}
