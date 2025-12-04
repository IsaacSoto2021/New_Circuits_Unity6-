using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SkillTreeManager : MonoBehaviour
{
    //stats
    public TMP_Text _HealthCounter;
    public TMP_Text _MovespeedCounter;
    public TMP_Text _DamageCounter;

    public TMP_Text _ScrapCounter;
    public TMP_Text _CryptoCounter;
    public TMP_Text _ElectronicsCounter;
    //popups
    public GameObject _UncDamagePopup;
    public GameObject _UncSpeedPopup;
    public GameObject _UncHPPopup;

    public GameObject _RareDamagePopup;
    public GameObject _RareSpeedPopup;
    public GameObject _RareHPPopup;

    public GameObject _EpicDamagePopup;
    public GameObject _EpicSpeedPopup;
    public GameObject _EpicHPPopup;
    //buy buttons
    public GameObject _BuyDamageButtonUnc;
    public GameObject _BuyDamageButtonRare;
    public GameObject _BuyDamageButtonEpic;

    public GameObject _BuySpeedButtonUnc;
    public GameObject _BuySpeedButtonRare;
    public GameObject _BuySpeedButtonEpic;

    public GameObject _BuyHPButtonUnc;
    public GameObject _BuyHPButtonRare;
    public GameObject _BuyHPButtonEpic;
    //costs
    public GameObject _DamageCostUnc;
    public GameObject _DamageCostRare;
    public GameObject _DamageCostEpic;

    public GameObject _HealthCostUnc;
    public GameObject _HealthCostRare;
    public GameObject _HealthCostEpic;

    public GameObject _SpeedCostUnc;
    public GameObject _SpeedCostRare;
    public GameObject _SpeedCostEpic;
    private void Update()
    {
        int _Health = PlayerData.Instance._maxHp;
        float _Movespeed = PlayerData.Instance._moveSpeed;
        int _Damage = PlayerData.Instance._damage;

        _HealthCounter.SetText("Health: " + _Health);
        _MovespeedCounter.SetText("Move Speed: " + _Movespeed);
        _DamageCounter.SetText("Damage: " + _Damage);

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

        _DamageCostUnc.SetActive(false);
        _DamageCostRare.SetActive(false);
        _DamageCostEpic.SetActive(false);

        _HealthCostUnc.SetActive(false);
        _HealthCostRare.SetActive(false);
        _HealthCostEpic.SetActive(false);

        _SpeedCostUnc.SetActive(false);
        _SpeedCostRare.SetActive(false);
        _SpeedCostEpic.SetActive(false);
    }
    public void ClickUncommonHP()
    {
        if (PlayerData.Instance._hasUncHP == false)
        {
            DisableAllPopups();
            _UncHPPopup.SetActive(true);
            _BuyHPButtonUnc.SetActive(true);
            _HealthCostUnc.SetActive(true);
        }


    }
    public void ClickUncommonSpeed()
    {
        if (PlayerData.Instance._hasUncSpeed == false)
        {

            DisableAllPopups();
            _UncSpeedPopup.SetActive(true);
            _BuySpeedButtonUnc.SetActive(true);
            _SpeedCostUnc.SetActive(true);
        }
    }
    public void ClickUncommonDamage()
    {
        if (PlayerData.Instance._hasUncDamage == false)
        {

            DisableAllPopups();
            _UncDamagePopup.SetActive(true);
            _BuyDamageButtonUnc.SetActive(true);
            _DamageCostUnc.SetActive(true);
        }
    }
    public void ClickRareHP()
    {
        if (PlayerData.Instance._hasRareHP == false)
        {

            DisableAllPopups();
            _RareHPPopup.SetActive(true);
            _BuyHPButtonRare.SetActive(true);
            _HealthCostRare.SetActive(true);
        }
    }
    public void ClickRareSpeed()
    {
        if (PlayerData.Instance._hasRareSpeed == false)
        {

            DisableAllPopups();
            _RareSpeedPopup.SetActive(true);
            _BuySpeedButtonRare.SetActive(true);
            _SpeedCostRare.SetActive(true);
        }
    }
    public void ClickRareDamage()
    {
        if (PlayerData.Instance._hasRareDamage == false)
        {

            DisableAllPopups();
            _RareDamagePopup.SetActive(true);
            _BuyDamageButtonRare.SetActive(true);
            _DamageCostRare.SetActive(true);
        }
    }
    public void ClickEpicHP()
    {
        if (PlayerData.Instance._hasEpicHP == false)
        {

            DisableAllPopups();
            _EpicHPPopup.SetActive(true);
            _BuyHPButtonEpic.SetActive(true);
            _HealthCostEpic.SetActive(true);
        }
    }
    public void ClickEpicSpeed()
    {
        if (PlayerData.Instance._hasEpicSpeed == false)
        {

            DisableAllPopups();
            _EpicSpeedPopup.SetActive(true);
            _BuySpeedButtonEpic.SetActive(true);
            _SpeedCostEpic.SetActive(true);
        }
    }
    public void ClickEpicDamage()
    {
        if (PlayerData.Instance._hasEpicDamage == false)
        {

            DisableAllPopups();
            _EpicDamagePopup.SetActive(true);
            _BuyDamageButtonEpic.SetActive(true);
            _DamageCostEpic.SetActive(true);
        }
    }

    public void ClickBuyUncDamage()
    {
        if (PlayerData.Instance._crypto >= 200)
        {
            PlayerData.Instance._crypto -= 200;
            PlayerData.Instance._damage += 25;
            PlayerData.Instance._hasUncDamage = true;
            Debug.Log(PlayerData.Instance._crypto + PlayerData.Instance._damage);
            DisableAllPopups();

        }

    }
    public void ClickBuyUncSpeed()
    {
        if (PlayerData.Instance._crypto >= 200)
        {
            PlayerData.Instance._crypto -= 200;
            PlayerData.Instance._moveSpeed += 0.5f;
            PlayerData.Instance._hasUncSpeed = true;
            Debug.Log(PlayerData.Instance._crypto + PlayerData.Instance._moveSpeed);
            DisableAllPopups();

        }
    }
    public void ClickBuyUncHP()
    {
        if (PlayerData.Instance._crypto >= 200)
        {
            PlayerData.Instance._crypto -= 200;
            PlayerData.Instance._maxHp += 20;
            PlayerData.Instance._hasUncHP = true;

            Debug.Log(PlayerData.Instance._crypto + PlayerData.Instance._maxHp);
            DisableAllPopups();

        }
    }
    public void ClickBuyRareDamage()
    {
        if (PlayerData.Instance._crypto >= 200 && PlayerData.Instance._scrap >= 100)
        {
            PlayerData.Instance._crypto -= 200;
            PlayerData.Instance._scrap -= 100;
            PlayerData.Instance._damage += 25;
            PlayerData.Instance._hasRareDamage = true;

            Debug.Log(PlayerData.Instance._crypto + PlayerData.Instance._scrap + PlayerData.Instance._damage);
            DisableAllPopups();

        }
    }
    public void ClickBuyRareSpeed()
    {
        if (PlayerData.Instance._crypto >= 200 && PlayerData.Instance._scrap >= 100)
        {
            PlayerData.Instance._crypto -= 200;
            PlayerData.Instance._scrap -= 100;
            PlayerData.Instance._moveSpeed += 0.5f;
            PlayerData.Instance._hasRareSpeed = true;

            Debug.Log(PlayerData.Instance._crypto + PlayerData.Instance._scrap + PlayerData.Instance._moveSpeed);
            DisableAllPopups();

        }
    }
    public void ClickBuyRareHP()
    {
        if (PlayerData.Instance._crypto >= 200 && PlayerData.Instance._scrap >= 100)
        {
            PlayerData.Instance._crypto -= 200;
            PlayerData.Instance._scrap -= 100;
            PlayerData.Instance._maxHp += 20;
            PlayerData.Instance._hasRareHP = true;

            Debug.Log(PlayerData.Instance._crypto + PlayerData.Instance._scrap + PlayerData.Instance._maxHp);
            DisableAllPopups();

        }
    }
    public void ClickBuyEpicDamage()
    {
        if (PlayerData.Instance._crypto >= 200 && PlayerData.Instance._scrap >= 100 && PlayerData.Instance._electronics >= 50)
        {
            PlayerData.Instance._crypto -= 200;
            PlayerData.Instance._scrap -= 100;
            PlayerData.Instance._electronics -= 50;
            PlayerData.Instance._damage += 25;
            PlayerData.Instance._hasEpicDamage = true;

            Debug.Log(PlayerData.Instance._crypto + PlayerData.Instance._scrap + PlayerData.Instance._electronics + PlayerData.Instance._damage);
            DisableAllPopups();

        }
    }
    public void ClickBuyEpicSpeed()
    {
        if (PlayerData.Instance._crypto >= 200 && PlayerData.Instance._scrap >= 100 && PlayerData.Instance._electronics >= 50)
        {
            PlayerData.Instance._crypto -= 200;
            PlayerData.Instance._scrap -= 100;
            PlayerData.Instance._electronics -= 50;
            PlayerData.Instance._moveSpeed += 1f;
            PlayerData.Instance._hasEpicSpeed = true;

            Debug.Log(PlayerData.Instance._crypto + PlayerData.Instance._scrap + PlayerData.Instance._electronics + PlayerData.Instance._moveSpeed);
            DisableAllPopups();

        }
    }
    public void ClickBuyEpicHP()
    {
        if (PlayerData.Instance._crypto >= 200 && PlayerData.Instance._scrap >= 100 && PlayerData.Instance._electronics >= 50)
        {
            PlayerData.Instance._crypto -= 200;
            PlayerData.Instance._scrap -= 100;
            PlayerData.Instance._electronics -= 50;
            PlayerData.Instance._maxHp += 40;
            PlayerData.Instance._hasEpicHP = true;

            Debug.Log(PlayerData.Instance._crypto + PlayerData.Instance._scrap + PlayerData.Instance._electronics + PlayerData.Instance._maxHp);
            DisableAllPopups();

        }

    }

}
