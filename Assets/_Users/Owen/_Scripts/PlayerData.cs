using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : Singleton<PlayerData>
{
    public int _maxHp = 100;
    public int _Hp = 0;
    public int _damage = 25;
    public float _moveSpeed = 3.0f;

    public int _scrap;
    public int _crypto;
    public int _electronics;

    public int _scrapToAdd;
    public int _cryptoToAdd;
    public int _electronicsToAdd;

    public bool _hasKeycard;

    private void Update()
    {
        if (_Hp > _maxHp)
        {
            _Hp = _maxHp;
        }
    }
    public void SetValues()
    {
        _Hp = _maxHp;
        Debug.Log("setvals");
    }

    private void Start()
    {
        SetValues();
    }

    public void LoseTempResources()
    {
        _scrapToAdd = 0;
        _electronicsToAdd = 0;
        _cryptoToAdd = 0;
    }

    public void GainTempResources()
    {
        _scrap += _scrapToAdd;
        _scrapToAdd = 0;
        _crypto += _cryptoToAdd;
        _cryptoToAdd = 0;
        _electronics += _electronicsToAdd;
        _electronicsToAdd = 0;
        Debug.Log("Scrap: " + _scrap);
        Debug.Log("Electronics: " + _electronics);
        Debug.Log("Crypto: " + _crypto);

    }

}
