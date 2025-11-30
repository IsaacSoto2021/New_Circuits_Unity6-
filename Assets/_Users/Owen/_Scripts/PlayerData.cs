using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
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
    public int _kills;
    public int _runs;

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
        if (Keyboard.current.numpad0Key.wasPressedThisFrame)
        {
            SaveSystem.Save();
            Debug.Log("save");
        }
        if (Keyboard.current.numpad1Key.wasPressedThisFrame)
        {
            SaveSystem.Load();
            Debug.Log("load");

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
        SaveSystem.Load();
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
    public void Save(ref PlayerSaveInfo data)
    {
        data._scrap = _scrap;
        data._crypto = _crypto;
        data._electronics = _electronics;

        data._runs = _runs;
        data._kills = _kills;

        data._maxHp = _maxHp;
        data._damage = _damage;
        data._moveSpeed = _moveSpeed;
    }

    public void Load(ref PlayerSaveInfo data)
    {
        _scrap = data._scrap;
        _crypto = data._crypto;
        _electronics = data._electronics;

        _maxHp = data._maxHp;
        _damage = data._damage;
        _moveSpeed = data._moveSpeed;

        _kills = data._kills;
        _runs = data._runs;
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveSystem.Save();
        }
    }

    private void OnApplicationQuit()
    {
        SaveSystem.Save();
    }
}

[System.Serializable]
public struct PlayerSaveInfo
{
    public int _maxHp;
    public int _damage;
    public float _moveSpeed;

    public int _scrap;
    public int _crypto;
    public int _electronics;

    public int _kills;
    public int _runs;
}