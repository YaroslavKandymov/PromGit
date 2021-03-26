using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _health;
    }
}
