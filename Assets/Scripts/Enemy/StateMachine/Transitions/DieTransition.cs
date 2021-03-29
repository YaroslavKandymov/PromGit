using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class DieTransition : Transition
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.Dying += OnMakeTransit;
    }

    private void OnDisable()
    {
        _enemy.Dying -= OnMakeTransit;
    }

    private void OnMakeTransit(Enemy enemy)
    {
        NeedTransit = true;
    }
}
