using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{

    public TMP_Text _HpText;
    public TMP_Text _ScrapText;

    // Update is called once per frame
    void Update()
    {
        int _Hp = PlayerData.Instance._Hp;
        int _Scrap = PlayerData.Instance._scrap + PlayerData.Instance._scrapToAdd;

        _HpText.SetText("" + _Hp);
        _ScrapText.SetText("" + _Scrap);

    }
}
