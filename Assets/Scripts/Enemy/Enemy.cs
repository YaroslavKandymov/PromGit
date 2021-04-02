using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _headCoefficient;
    [SerializeField] private Collider _headCollider;
    [SerializeField] private Collider _bodyCollider;

    public Collider HeadCollider => _headCollider;
    public Collider BodyCollider => _bodyCollider;
    public Player Target { get; private set; }

    public event UnityAction<Enemy> Dying;

    public void Init(Player target)
    {
        Target = target;
    }

    public void TakeDamageInHead(int damage)
    {
        _health -= damage * _headCoefficient;

        if(_health <= 0)
        {
            Dying?.Invoke(this);
        }
    }

    public void TakeDamageInBody(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Dying?.Invoke(this);
        }
    }

    public void IncreaseHealth(int count)
    {
        _health *= count;
    }
}
