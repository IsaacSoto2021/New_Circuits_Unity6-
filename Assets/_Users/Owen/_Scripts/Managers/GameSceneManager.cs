using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSceneManager : MonoBehaviour
{
    public int sceneNum = 1;
    public GameObject lvl1Indicator;
    public GameObject lvl2Indicator;
    public GameObject lvl3Indicator;
    public TMP_Text _CryptoCounter;
    private void Start()
    {
        int _Crypto = PlayerData.Instance._crypto;
        _CryptoCounter.SetText(": " + _Crypto);

    }
    private void Update()
    {
        if (sceneNum == 1)
        {
            GameManager.Instance.SceneIndexGoTo = 1;
            lvl2Indicator.SetActive(false);
            lvl3Indicator.SetActive(false);
            lvl1Indicator.SetActive(true);
        }
        if (sceneNum == 2)
        {
            GameManager.Instance.SceneIndexGoTo = 8;
            lvl1Indicator.SetActive(false);
            lvl3Indicator.SetActive(false);
            lvl2Indicator.SetActive(true);
        }
        if (sceneNum == 3)
        {
            GameManager.Instance.SceneIndexGoTo = 9;
            lvl1Indicator.SetActive(false);
            lvl2Indicator.SetActive(false);
            lvl3Indicator.SetActive(true);
        }
    }
    public void ClickStartRun()
    {
        PlayerData.Instance._runs++;
        PlayerData.Instance.LoseTempResources();
        GameManager.Instance.GameScene();
    }
    public void ClickSkillTree()
    {
        GameManager.Instance.SkillTree();
    }
    public void ClickNextLevel()
    {
        sceneNum++;
        if (sceneNum > 3)
        {
            sceneNum = 3;
        }
    }
    public void ClickPreviousLevel()
    {
        sceneNum--;
        if (sceneNum <= 0)
        {
            sceneNum = 1;
        }
    }
    public void ClickBackToMainMenu()
    {
        GameManager.Instance.Return();
    }
    public void ClickStats()
    {
        GameManager.Instance.Stats();
    }

}
