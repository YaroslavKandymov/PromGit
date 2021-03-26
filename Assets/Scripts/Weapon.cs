using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : ObjectPool
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;

    private void Start()
    {
        Initialize(_bulletPrefab);
    }

    public void Shoot()
    {
        if (TryGetObject(out _bulletPrefab))
        {
            SetBullet();
        }
    }

    private void SetBullet()
    {
        _bulletPrefab.SetActive(true);
        _bulletPrefab.transform.position = _spawnPoint.position;
    }
}
