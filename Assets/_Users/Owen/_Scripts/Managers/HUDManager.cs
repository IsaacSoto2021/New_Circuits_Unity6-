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

    // Update is called once per frame
    void Update()
    {
        int _Hp = PlayerData.Instance._Hp;
        int _Scrap = PlayerData.Instance._scrap + PlayerData.Instance._scrapToAdd;
        int _Crypto = PlayerData.Instance._crypto + PlayerData.Instance._cryptoToAdd;
        int _Electronics = PlayerData.Instance._electronics + PlayerData.Instance._electronicsToAdd;

        _HpText.SetText("" + _Hp);//hud icon text

        _iScrapText.SetText(":" + _Scrap);//inventory text
        _iCryptoText.SetText(":" + _Crypto);
        _iElectronicsText.SetText(":" + _Electronics);
    }

    private void Start()
    {
        _isInventoryOpen = false;
        _isOBJListOpen = false;
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
