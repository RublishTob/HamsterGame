using UnityEngine;

[RequireComponent (typeof(Movable))]
public class Rotatable : MonoBehaviour, IRotatable
{
    private Movable _movable;
    private float _desiredRotation = 0f;
    private float _rotationSpeed = 10f;
    private Quaternion _currentRotation;
    private Quaternion _targetRotation;

    private void Start()
    {
        _movable = GetComponent<Movable>();
    }

    private void Update()
    {
        CalculateCurrentRotation();
        Rotate(_targetRotation, _rotationSpeed);
    }

    public void Rotate(Quaternion target,float speed)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, target, speed * Time.deltaTime);
    }
    private void CalculateCurrentRotation()
    {
        if (_movable.RotatedMovement.magnitude > 0)
            _desiredRotation = Mathf.Atan2(_movable.RotatedMovement.x, _movable.RotatedMovement.z) * Mathf.Rad2Deg;

        _currentRotation = transform.rotation;
        _targetRotation = Quaternion.Euler(0, _desiredRotation, 0);
    }

}
