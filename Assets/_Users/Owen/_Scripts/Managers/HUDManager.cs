using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public GameObject _pauseMenu;

    public TMP_Text _HpText;
    public TMP_Text _iScrapText;
    public TMP_Text _iCryptoText;
    public TMP_Text _iElectronicsText;
    public GameObject _Inventory;

    private bool _isInventoryOpen;

    // Update is called once per frame
    void Update()
    {
        int _Hp = PlayerData.Instance._Hp;
        int _Scrap = PlayerData.Instance._scrap + PlayerData.Instance._scrapToAdd;
        int _Crypto = PlayerData.Instance._crypto + PlayerData.Instance._cryptoToAdd;
        int _Electronics = PlayerData.Instance._electronics + PlayerData.Instance._electronicsToAdd;

        _HpText.SetText("" + _Hp);//hud icon text

        _iScrapText.SetText("Scrap: " + _Scrap);//inventory text
        _iCryptoText.SetText("Crypto: " + _Crypto);
        _iElectronicsText.SetText("Electronics: " + _Electronics);
    }

    private void Start()
    {
        _isInventoryOpen = false;
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
}
