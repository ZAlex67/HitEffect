using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private MouseRotator _rotation;
    [SerializeField] private BulletMover _bulletMover;

    private float _timeToFire = 0;

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= _timeToFire)
        {
            _timeToFire = Time.time + 1 / _bulletMover.FireRate;
            SpawnVFX();
        }
    }

    private void SpawnVFX()
    {
        Instantiate(_bulletMover, _firePoint.transform.position, _rotation.GetRotation());
    }
}