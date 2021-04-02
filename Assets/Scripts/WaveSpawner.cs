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

    private List<Wave> _waves;
    private List<Enemy> _enemies;
    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;
    private int _dead;
    private int _currentWaveCount;

    public event UnityAction<int> WaveStarted;
    public int CurrentWaveNumber => _currentWaveNumber;

    private void Start()
    {
        InitializeSpawner();
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
            _currentWave = null;
    }

    public void Reset()
    {
        foreach (var enemy in _enemies)
            Destroy(enemy?.gameObject);

        _currentWaveCount = 0;
        _currentWaveNumber = 0;
        _dead = 0;
        _spawned = 0;
        _enemies.Clear();
        _waves.Clear();
        InitializeSpawner();
    }

    private void InitializeSpawner()
    {
        _waves = new List<Wave>
        {
            _firstWave
        };

        _enemies = new List<Enemy>();

        SetWave(_currentWaveNumber);
        WaveStarted?.Invoke(_currentWaveNumber);
    }

    private void InstantiateEnemy()
    {
        int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoints[spawnPointNumber].position, Quaternion.identity)
            .GetComponent<Enemy>();
        _enemies.Add(enemy);
        enemy.Init(_player);
        enemy.IncreaseHealth(_currentWaveNumber + 1);
        enemy.Dying += OnEnemyDying;
    }

    private void SetWave(int index)
    {
        _waves.Add(new Wave() { Template = _firstWave.Template, Delay = _firstWave.Delay });
        _currentWave = _waves[index];
        _currentWave.Count += _currentWaveCount + _currentWaveCount;
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

    private void OnEnemyDying(Enemy enemy)
    {
        _dead++;
        _enemies.Remove(enemy);
        enemy.Dying -= OnEnemyDying;
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}
