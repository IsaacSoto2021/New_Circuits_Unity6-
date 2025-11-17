using TMPro;
using UnityEngine;

public class DeathScreenManager : MonoBehaviour
{
    public TMP_Text _ScrapCounter;
    public TMP_Text _CryptoCounter;
    public TMP_Text _ElectronicsCounter;
    public TMP_Text _KillsCounter;

    private void Update()
    {
        int _Scrap = PlayerData.Instance._scrap;
        int _Crypto = PlayerData.Instance._crypto;
        int _Electronics = PlayerData.Instance._electronics;
        int _Kills = PlayerData.Instance._kills;

        _ScrapCounter.SetText("Scrap: " + _Scrap);
        _CryptoCounter.SetText("Crypto: " + _Crypto);
        _ElectronicsCounter.SetText("Electronics: " + _Electronics);
        _ElectronicsCounter.SetText("Kills: " + _Kills);
    }
    public void ClickBackToHQ()
    {
        GameManager.Instance.Play();
    }
    public void ClickQuit()
    {
        GameManager.Instance.Quit();
    }
}
