using UnityEngine;

public class MouseRotator : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxLength;

    private Ray _rayMouse;
    private Vector3 _direction;
    private Quaternion _rotation;

    private void Update()
    {
        RaycastHit hit;
        Vector3 mousePosition = Input.mousePosition;
        _rayMouse = _camera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(_rayMouse.origin, _rayMouse.direction, out hit, _maxLength))
        {
            RotateToMouseDirection(gameObject, hit.point);
        }
        else
        {
            Vector3 position = _rayMouse.GetPoint(_maxLength);
            RotateToMouseDirection(gameObject, position);
        }
    }

    private void RotateToMouseDirection(GameObject obj, Vector3 destination)
    {
        _direction = destination - obj.transform.position;
        _rotation = Quaternion.LookRotation(_direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, _rotation, 1);
    }

    public Quaternion GetRotation()
    {
        return _rotation;
    }
}