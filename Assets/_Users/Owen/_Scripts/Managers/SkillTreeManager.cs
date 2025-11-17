using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SkillTreeManager : MonoBehaviour
{
    public TMP_Text _ScrapCounter;
    public TMP_Text _CryptoCounter;
    public TMP_Text _ElectronicsCounter;

    private void Update()
    {
        int _Scrap = PlayerData.Instance._scrap;
        int _Crypto = PlayerData.Instance._crypto;
        int _Electronics = PlayerData.Instance._electronics;

        _ScrapCounter.SetText("Scrap: " + _Scrap);
        _CryptoCounter.SetText("Crypto: " + _Crypto);
        _ElectronicsCounter.SetText("Electronics: " + _Electronics);
    }
    public void ClickReturnFromSkillTree()
    {
        GameManager.Instance.ReturnFromSkillTree();
    }
}
