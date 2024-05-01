using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float _rotationSpeed;

    private float _currentRotation = 0;

    void Start()
    {
        _currentRotation -= Time.deltaTime * _rotationSpeed;
        transform.rotation = Quaternion.Euler(0, _currentRotation, 0);
    }
    public void ResetRotation()
    {
        _currentRotation = 0;
    }
}
