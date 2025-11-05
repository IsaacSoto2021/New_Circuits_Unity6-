using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void ClickQuit()
    {
        GameManager.Instance.Quit();
    }
    public void ClickPlay()
    {
        GameManager.Instance.Play();
    }
    public void ClickReturn()
    {
        GameManager.Instance.Return();
    }

}
