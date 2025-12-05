using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public GameObject _pauseMenu;
    public GameObject _objMenu;

    public TMP_Text _HpText;
    public TMP_Text _iScrapText;
    public TMP_Text _iCryptoText;
    public TMP_Text _iElectronicsText;
    public GameObject _Inventory;

    private bool _isInventoryOpen;
    private bool _isOBJListOpen;

    public GameObject _RedKeycardIcon;
    public GameObject _BlueKeycardIcon;
    public GameObject _GreenKeycardIcon;

    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;
    public GameObject Heart5;
    public GameObject Heart6;

    // Update is called once per frame
    void Update()
    {
        int _Hp = PlayerData.Instance._Hp;
        int _Scrap = PlayerData.Instance._scrap + PlayerData.Instance._scrapToAdd;
        int _Crypto = PlayerData.Instance._crypto + PlayerData.Instance._cryptoToAdd;
        int _Electronics = PlayerData.Instance._electronics + PlayerData.Instance._electronicsToAdd;
        //float _PercentHp = ((PlayerData.Instance._Hp / PlayerData.Instance._maxHp) * 100);
        //Debug.Log(_PercentHp);

        _HpText.SetText("" + _Hp);//hud icon text

        _iScrapText.SetText(":" + _Scrap);//inventory text
        _iCryptoText.SetText(":" + _Crypto);
        _iElectronicsText.SetText(":" + _Electronics);

        if (PlayerData.Instance._hasKeycardRed)
        {
            _RedKeycardIcon.SetActive(true);
        }
        if (!PlayerData.Instance._hasKeycardRed)
        {
            _RedKeycardIcon.SetActive(false);
        }
        if (PlayerData.Instance._hasKeycardBlue)
        {
            _BlueKeycardIcon.SetActive(true);
        }
        if (!PlayerData.Instance._hasKeycardBlue)
        {
            _BlueKeycardIcon.SetActive(false);
        }
        if (PlayerData.Instance._hasKeycardGreen)
        {
            _GreenKeycardIcon.SetActive(true);
        }
        if (!PlayerData.Instance._hasKeycardGreen)
        {
            _GreenKeycardIcon.SetActive(false);
        }
        /* if (_PercentHp == 100)
         {
             HideAllHearts();
             Heart1.SetActive(true);
         }
         if ((_PercentHp < 100) && (_PercentHp >= 76))
         {
             HideAllHearts();
             Heart2.SetActive(true);

         }
         if ((_PercentHp < 76) && (_PercentHp >= 51))
         {
             HideAllHearts();
             Heart3.SetActive(true);

         }
         if ((_PercentHp < 50) && (_PercentHp >= 26))
         {
             HideAllHearts();
             Heart4.SetActive(true);

         }
         if ((_PercentHp < 26) && (_PercentHp >= 1))
         {
             HideAllHearts();
             Heart5.SetActive(true);

         }
         if (_PercentHp <= 0)
         {
             HideAllHearts();
             Heart6.SetActive(true);
         }*/
    }

    private void Start()
    {
        _isInventoryOpen = false;
        _isOBJListOpen = false;
    }

    public void HideAllHearts()
    {
        Heart1.SetActive(false);
        Heart2.SetActive(false);
        Heart3.SetActive(false);
        Heart4.SetActive(false);
        Heart5.SetActive(false);
        Heart6.SetActive(false);
    }
    public void OpenAndCloseInventory()
    {
        if (!_isInventoryOpen)
        {
            _Inventory.SetActive(true);
            _isInventoryOpen = true;
        }
        else if (_isInventoryOpen)
        {
            _Inventory.SetActive(false);
            _isInventoryOpen = false;
        }
    }
    public void OpenAndCloseOBJs()
    {
        if (!_isOBJListOpen)
        {
            _objMenu.SetActive(true);
            _isOBJListOpen = true;
        }
        else if (_isOBJListOpen)
        {
            _objMenu.SetActive(false);
            _isOBJListOpen = false;
        }
    }

}
