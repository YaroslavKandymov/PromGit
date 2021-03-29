﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnWave : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Player _player;
    [SerializeField] private float _timeBetweenWaves;
    [SerializeField] private Wave _firstWave;

    private List<Wave> _waves;
    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;
    private int _dead;

    private void Start()
    {
        _waves = new List<Wave>
        {
            _firstWave
        };

        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
        }

        if (_dead >= _currentWave.Count)
        {
            _dead = 0;
            StartCoroutine(SetNextWave(_timeBetweenWaves));
        }
    }

    private void InstantiateEnemy()
    {
        int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoints[spawnPointNumber].position, Quaternion.identity)
            .GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.Dying += OnEnemyDying;
    }

    private void OnEnemyDying(Enemy enemy)
    {
        _dead++;
        enemy.Dying -= OnEnemyDying;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    private IEnumerator SetNextWave(float seconds)
    {
        Debug.Log("Корутина");
        yield return new WaitForSeconds(seconds);
        SetWave(++_currentWaveNumber);
        _currentWave.Count += _currentWave.Count;
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}
