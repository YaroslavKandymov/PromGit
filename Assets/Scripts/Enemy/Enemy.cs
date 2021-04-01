using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Collider _headCollider;
    [SerializeField] private Collider _bodyCollider;

    private Player _target;

    public Collider HeadCollider => _headCollider;
    public Collider BodyCollider => _bodyCollider;
    public Player Target => _target;

    public event UnityAction<Enemy> Dying;

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamageInHead(int damage)
    {
        _health -= damage * 2;

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
