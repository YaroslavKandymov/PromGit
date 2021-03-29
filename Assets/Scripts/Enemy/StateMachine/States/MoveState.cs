using UnityEngine;
using DG.Tweening;

public class MoveState : State
{
    [SerializeField] private float _speed;
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
        transform.LookAt(Target.transform);
    }
}
