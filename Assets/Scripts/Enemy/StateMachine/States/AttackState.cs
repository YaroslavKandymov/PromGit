using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AttackState : MonoBehaviour
{
    [SerializeField] private int _damage;

    private float _lastAttackTime;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
