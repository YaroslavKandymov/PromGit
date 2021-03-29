using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _maxExistTime;
    [SerializeField] private float _forceSpeed;

    private float _elapsedTime = 0;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(Vector3.forward * _forceSpeed, ForceMode.Force);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        
        if (_elapsedTime >= _maxExistTime)
        {
            gameObject.SetActive(false);
            _elapsedTime = 0;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }

        gameObject.SetActive(false);
    }
}
