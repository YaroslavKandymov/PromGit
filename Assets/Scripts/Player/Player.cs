using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _timeBeforeRecover;
    [SerializeField] private float _recoverDuration;

    private float _currentHealth;
    private Coroutine _coroutine;

    public event UnityAction OnDied;
    public event UnityAction<float, float> HealthChanged;
    public event UnityAction TakenDamage;

    private void Start()
    {
        Reset();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ApplyDamage(int damage)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _currentHealth -= damage;

        HealthChanged?.Invoke(_currentHealth, _health);
        TakenDamage?.Invoke();

        _coroutine = StartCoroutine(RecoverHealth());

        if (_currentHealth <= 0)
        {
            OnDied?.Invoke();
        }
    }

    public IEnumerator RecoverHealth()
    {
        yield return new WaitForSeconds(_timeBeforeRecover);
        _currentHealth = _health;
        HealthChanged?.Invoke(_currentHealth, _health);
    }

    public void Reset()
    {
        _currentHealth = _health;
        transform.position = _startPosition;
    }
}
