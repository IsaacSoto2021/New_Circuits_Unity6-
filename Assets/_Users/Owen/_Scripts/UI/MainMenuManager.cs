using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; //SPLIT THIS BY SCENE B4 IMPLEMENTATION !!!IMPORTANT!!!

public class MainMenuManager : MonoBehaviour
{
    public TMP_Text _scrapText;

    public void Update()
    {
        int _scrap = PlayerData.Instance._scrap;

        _scrapText.SetText("Currency: " + _scrap);
    }
    public void ClickQuit()
    {
        GameManager.Instance.Quit();
    }
    public void ClickPlay()
    {
        PlayerData.Instance.LoseTempScrap();
        GameManager.Instance.Play();
    }
    public void ClickSkillTree()
    {
        GameManager.Instance.SkillTree();
    }
    public void ClickReturn()
    {
        GameManager.Instance.Return();
    }

}
