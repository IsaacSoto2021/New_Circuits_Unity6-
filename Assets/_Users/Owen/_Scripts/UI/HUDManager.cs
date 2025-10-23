using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public GameObject _pauseMenu;

    public TMP_Text _HpText;
    public TMP_Text _ScrapText;
    public TMP_Text _InventoryText;
    public GameObject _Inventory;

    private bool _isInventoryOpen;

    // Update is called once per frame
    void Update()
    {
        int _Hp = PlayerData.Instance._Hp;
        int _Scrap = PlayerData.Instance._scrap + PlayerData.Instance._scrapToAdd;

        _HpText.SetText("" + _Hp);
        _ScrapText.SetText("" + _Scrap);

        _InventoryText.SetText("Scrap: " + PlayerData.Instance._scrapToAdd + "\nCrypto: " + PlayerData.Instance._cryptoToAdd + "\nElectronics: " + PlayerData.Instance._electronicsToAdd);
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
