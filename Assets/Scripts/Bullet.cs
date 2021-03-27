using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxExistTime;

    private float _elapcedTime = 0;

    private void Update()
    {
        _elapcedTime += Time.deltaTime;
        transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.World);

        if(_elapcedTime >= _maxExistTime)
        {
            gameObject.SetActive(false);
            _elapcedTime = 0;
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
