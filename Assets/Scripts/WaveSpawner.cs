using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Player _player;
    [SerializeField] private float _timeBetweenWaves;
    [SerializeField] private Wave _firstWave;

    public event UnityAction<int> WaveStarted;

    private List<Wave> _waves;
    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;
    private int _dead;
    private int _currentWaveCount;

    private void Start()
    {
        _waves = new List<Wave>();
        _waves.Add(_firstWave);

        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_dead >= _currentWaveCount)
        {
            StartCoroutine(SetNextWave(_timeBetweenWaves));
            _dead = 0;
        }

        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
        }

        if (_currentWave.Count <= _spawned)
        {
            _currentWave = null;
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
        _waves.Add(new Wave() { Template = _firstWave.Template, Delay = _firstWave.Delay});
        _currentWave = _waves[index];
        _currentWave.Count += _currentWaveCount * 2;
        _currentWaveCount = _currentWave.Count;
    }

    private IEnumerator SetNextWave(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _dead = 0;
        _spawned = 0;
        SetWave(++_currentWaveNumber);
        WaveStarted?.Invoke(_currentWaveNumber);
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}
