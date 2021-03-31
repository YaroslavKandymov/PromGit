using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Vector3 _startPosition;

    private int _currentHealth;

    public event UnityAction OnDied;

    private void Start()
    {
        Reset();
        Cursor.visible = false;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            OnDied?.Invoke();
        }
    }

    public void Reset()
    {
        _currentHealth = _health;
        transform.position = _startPosition;
    }
}
