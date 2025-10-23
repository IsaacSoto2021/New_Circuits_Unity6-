using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : Singleton<PlayerData>
{
    public int _maxHp = 100;
    public int _Hp = 0;
    public int _hpTier = 1;
    public int _damage = 25;
    public float _moveSpeed = 3.0f;

    public int _scrap;
    public int _crypto;
    public int _electronics;

    public int _scrapToAdd;
    public int _cryptoToAdd;
    public int _electronicsToAdd;

    public bool _hasKeycard;

    public void SetValues()
    {
        _Hp = _maxHp;
        Debug.Log("setvals");
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
        SetValues();
    }

    public void LoseTempScrap()
    {
        _scrapToAdd = 0;
    }

    public void GainTempScrap()
    {
        _scrap += _scrapToAdd;
        Debug.Log(_scrap);
        _scrapToAdd = 0;
    }
}
