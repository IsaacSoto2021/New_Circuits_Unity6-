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

    public GameObject _UncDamagePopup;
    public GameObject _UncSpeedPopup;
    public GameObject _UncHPPopup;

    public GameObject _RareDamagePopup;
    public GameObject _RareSpeedPopup;
    public GameObject _RareHPPopup;

    public GameObject _EpicDamagePopup;
    public GameObject _EpicSpeedPopup;
    public GameObject _EpicHPPopup;

    public GameObject _BuyDamageButtonUnc;
    public GameObject _BuyDamageButtonRare;
    public GameObject _BuyDamageButtonEpic;

    public GameObject _BuySpeedButtonUnc;
    public GameObject _BuySpeedButtonRare;
    public GameObject _BuySpeedButtonEpic;

    public GameObject _BuyHPButtonUnc;
    public GameObject _BuyHPButtonRare;
    public GameObject _BuyHPButtonEpic;
    private void Update()
    {
        int _Scrap = PlayerData.Instance._scrap;
        int _Crypto = PlayerData.Instance._crypto;
        int _Electronics = PlayerData.Instance._electronics;

        _ScrapCounter.SetText("Scrap: " + _Scrap);
        _CryptoCounter.SetText("Crypto: " + _Crypto);
        _ElectronicsCounter.SetText("Electronics: " + _Electronics);
    }

    private void Start()
    {
        DisableAllPopups();
    }
    public void ClickReturnFromSkillTree()
    {
        GameManager.Instance.ReturnFromSkillTree();
    }

    public void DisableAllPopups()
    {
        _UncDamagePopup.SetActive(false);
        _RareDamagePopup.SetActive(false);
        _EpicDamagePopup.SetActive(false);
        _UncSpeedPopup.SetActive(false);
        _RareSpeedPopup.SetActive(false);
        _EpicSpeedPopup.SetActive(false);
        _UncHPPopup.SetActive(false);
        _RareHPPopup.SetActive(false);
        _EpicHPPopup.SetActive(false);

        _BuyDamageButtonUnc.SetActive(false);
        _BuyDamageButtonRare.SetActive(false);
        _BuyDamageButtonEpic.SetActive(false);
        _BuyHPButtonUnc.SetActive(false);
        _BuyHPButtonRare.SetActive(false);
        _BuyHPButtonEpic.SetActive(false);
        _BuySpeedButtonUnc.SetActive(false);
        _BuySpeedButtonRare.SetActive(false);
        _BuySpeedButtonEpic.SetActive(false);
    }
    public void ClickUncommonHP()
    {
        DisableAllPopups();
        _UncHPPopup.SetActive(true);
        _BuyHPButtonUnc.SetActive(true);
    }
    public void ClickUncommonSpeed()
    {
        DisableAllPopups();
        _UncSpeedPopup.SetActive(true);
        _BuySpeedButtonUnc.SetActive(true);
    }
    public void ClickUncommonDamage()
    {
        DisableAllPopups();
        _UncDamagePopup.SetActive(true);
        _BuyDamageButtonUnc.SetActive(true);
    }
    public void ClickRareHP()
    {
        DisableAllPopups();
        _RareHPPopup.SetActive(true);
        _BuyHPButtonRare.SetActive(true);
    }
    public void ClickRareSpeed()
    {
        DisableAllPopups();
        _RareSpeedPopup.SetActive(true);
        _BuySpeedButtonRare.SetActive(true);
    }
    public void ClickRareDamage()
    {
        DisableAllPopups();
        _RareDamagePopup.SetActive(true);
        _BuyDamageButtonRare.SetActive(true);
    }
    public void ClickEpicHP()
    {
        DisableAllPopups();
        _EpicHPPopup.SetActive(true);
        _BuyHPButtonEpic.SetActive(true);
    }
    public void ClickEpicSpeed()
    {
        DisableAllPopups();
        _EpicSpeedPopup.SetActive(true);
        _BuySpeedButtonEpic.SetActive(true);
    }
    public void ClickEpicDamage()
    {
        DisableAllPopups();
        _EpicDamagePopup.SetActive(true);
        _BuyDamageButtonEpic.SetActive(true);
    }

}
