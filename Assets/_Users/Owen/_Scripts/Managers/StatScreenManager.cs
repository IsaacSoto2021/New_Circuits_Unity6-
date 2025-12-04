using TMPro;
using UnityEngine;

public class StatScreenManager : MonoBehaviour
{
    public TMP_Text _ScrapCounter;
    public TMP_Text _CryptoCounter;
    public TMP_Text _ElectronicsCounter;
    public TMP_Text _KillsCounter;
    public TMP_Text _RunsCounter;
    public TMP_Text _HealthCounter;
    public TMP_Text _MovespeedCounter;
    public TMP_Text _DamageCounter;

    private void Update()
    {
        int _Scrap = PlayerData.Instance._scrap;
        int _Crypto = PlayerData.Instance._crypto;
        int _Electronics = PlayerData.Instance._electronics;
        int _Kills = PlayerData.Instance._kills;
        int _Runs = PlayerData.Instance._runs;
        int _Health = PlayerData.Instance._maxHp;
        float _Movespeed = PlayerData.Instance._moveSpeed;
        int _Damage = PlayerData.Instance._damage;

        _ScrapCounter.SetText("Scrap: " + _Scrap);
        _CryptoCounter.SetText("Crypto: " + _Crypto);
        _ElectronicsCounter.SetText("Electronics: " + _Electronics);
        _KillsCounter.SetText("Kills: " + _Kills);
        _RunsCounter.SetText("Runs: " + _Runs);
        _HealthCounter.SetText("Health: " + _Health);
        _MovespeedCounter.SetText("Move Speed: " + _Movespeed);
        _DamageCounter.SetText("Damage: " + _Damage);
    }
    public void ClickBackToHQ()
    {
        GameManager.Instance.Play();
    }
    public void ClickSettings()
    {
        //open settings menu
    }
}
