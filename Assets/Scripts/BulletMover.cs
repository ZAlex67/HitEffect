using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _fireRate;
    [SerializeField] private ParticleSystem _hitPrefab;

    public float FireRate => _fireRate;

    private void Update()
    {
        transform.Translate(transform.forward * (_speed * Time.deltaTime), Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _speed = 0;

        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;

        var hitVFX = Instantiate(_hitPrefab, position, rotation);
        Destroy(hitVFX, hitVFX.main.duration);

        Destroy(gameObject);
    }
}