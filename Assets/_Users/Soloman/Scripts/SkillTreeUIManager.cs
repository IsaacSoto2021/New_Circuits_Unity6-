using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillTreeUIManager : MonoBehaviour
{
    public TMP_Text _MaxHP1;
    public TMP_Text _Speed1;
    public TMP_Text _Damage1;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int _MaxHP = PlayerData.Instance._maxHp;
        float _Speed = PlayerData.Instance._moveSpeed;
        int _Damage = PlayerData.Instance._damage;

        _MaxHP1.SetText("Max HP: " + _MaxHP);
        _Speed1.SetText("Speed: " + _Speed);
        _Damage1.SetText("Damage: " + _Damage);
    }

    public void ClickReturn()
    {
        SceneManager.LoadScene(0);
    }
}
