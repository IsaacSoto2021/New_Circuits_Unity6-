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
        DontDestroyOnLoad(this);
        ResetPos();
        if (Player != null)
        {
            _playerRef = GameObject.FindWithTag("Player");
            Player = _playerRef.GetComponent<NavMeshAgent>();
        }
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
        SceneManager.LoadSceneAsync(1);
        _playerRef = GameObject.FindWithTag("Player");
        Player = _playerRef.GetComponent<NavMeshAgent>();
        ResetPos();
        PlayerData.Instance.SetValues();
    }
    public void SkillTree()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void Return()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
