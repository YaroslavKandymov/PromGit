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
        Cursor.visible = false;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Debug.Log("Смэрть");
        }
    }

}
