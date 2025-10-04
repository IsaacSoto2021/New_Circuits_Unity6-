using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    public GameObject _enemy1;
    public GameObject _enemy2;
    public GameObject _enemy3;
    public GameObject _enemy4;
    public Transform _enemySpawn;

    private void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        _enemy1.SetActive(true);
        _enemy2.SetActive(true);
        _enemy3.SetActive(true);
        _enemy4.SetActive(true);
    }

}
