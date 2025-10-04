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
    public int _scrap;
    public int _damage = 50;
    public float _moveSpeed = 3.0f;
    public int _scrapToAdd = 0;

    public bool _hasKeycard;

    public void SetValues()
    {
        _Hp = _maxHp;
    }

    private void Start()
    {
        SetValues();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("EnemyProjectile20"))
        {
            _Hp -= 20;
            if (_Hp <= 0)
            {
                SceneManager.LoadScene(0);
                LoseTempScrap();
            }
        }
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
