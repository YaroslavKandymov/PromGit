using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    public void Shoot()
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

        Ray ray = _camera.ScreenPointToRay(point);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDamage(_damage);
            }
        }
    }
}
