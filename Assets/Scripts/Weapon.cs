using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _fire;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    public void Shoot()
    {
        _fire.Play();

        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

        Ray ray = _camera.ScreenPointToRay(point);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            if (hitObject.TryGetComponent(out Enemy enemy))
            {
                if (hit.collider == enemy.HeadCollider)
                    enemy.TakeDamageInHead(_damage);

                else if (hit.collider == enemy.BodyCollider)
                    enemy.TakeDamageInBody(_damage);
            }
        }
    }
}
