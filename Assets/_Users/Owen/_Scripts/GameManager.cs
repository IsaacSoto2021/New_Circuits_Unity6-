using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] NavMeshAgent Player;
    [SerializeField] GameObject _playerControllerPrefab;

    [SerializeField] Vector3 _spawnPoint;

    private void Start()
    {
        DontDestroyOnLoad(this);
        ResetPos();
    }
    public void ResetPos()
    {
        Player.Warp(_spawnPoint);
        PlayerData.Instance.SetValues();
    }
    public void Quit()
    {
        print("Quit Game");
        Application.Quit();
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
        ResetPos();
        PlayerData.Instance.SetValues();
    }
    public void SkillTree()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void Return()
    {
        SceneManager.LoadScene(0);
    }
}
