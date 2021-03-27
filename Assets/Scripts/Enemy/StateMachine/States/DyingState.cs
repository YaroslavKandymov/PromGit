using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class DyingState : State
{
    [SerializeField] private float _seconds;

    private Animator _animator;
    private Collider _collider;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();

        StartCoroutine(Dying(_seconds));
    }

    private IEnumerator Dying(float seconds)
    {
        _animator.Play("Dying");
        _collider.enabled = false;

        yield return new WaitForSeconds(seconds);

        gameObject.SetActive(false);
    }
}
