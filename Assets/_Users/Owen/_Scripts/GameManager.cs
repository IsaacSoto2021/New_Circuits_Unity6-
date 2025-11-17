using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public NavMeshAgent Player;
    private GameObject _playerRef;

    [SerializeField] Vector3 _spawnPoint;

    private void Start()
    {

        if (Player != null)
        {
            _playerRef = GameObject.FindWithTag("Player");
            Player = _playerRef.GetComponent<NavMeshAgent>();
        }
        DontDestroyOnLoad(this);
        // ResetPos();
    }
    public void ResetPos()
    {
        //Player.Warp(_spawnPoint);
        PlayerData.Instance.SetValues();
    }
    public void Quit()
    {
        print("Quit Game");
        Application.Quit();
    }
    public void Play()
    {
        SceneManager.LoadSceneAsync(3);
        Time.timeScale = 1.0f;
    }
    public void SkillTree()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void Return()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void ReturnFromSkillTree()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void Stats()
    {
        SceneManager.LoadSceneAsync(6);
    }
    public void GameScene()
    {
        SceneManager.LoadSceneAsync(1);
        //_playerRef = GameObject.FindWithTag("Player");
        //Player = _playerRef.GetComponent<NavMeshAgent>();
        //ResetPos();
        PlayerData.Instance.SetValues();
    }
}
