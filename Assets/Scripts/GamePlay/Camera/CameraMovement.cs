using UnityEngine;

public class CameraMovement: MonoBehaviour
{
    private PlayerViewDetect _target;
    private Transform _targetOfCamera;
    [SerializeField] private InputHandler _playerInput;

    [SerializeField] private Vector2 _rotationYMinMax;
    [SerializeField] private LayerMask _maskObstacles;

    [SerializeField] private float _mouseSensitivity = 0.1f;
    [SerializeField] private float _distanceFromTarget = 3.0f;
    [SerializeField] private float _smoothTime = 0.2f;

    private float _rotationClamp = 40;
    private float _rotationX;
    private float _rotationY;

    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;
    private void Start()
    {
        _rotationYMinMax = new Vector2(-_rotationClamp, _rotationClamp);
        _target = FindObjectOfType<PlayerViewDetect>();
        _targetOfCamera = _target.TargetOfCamera;
    }

    private void LateUpdate()
    {
        RotateCamera();
    }
    private void RotateCamera()
    {
        if (_playerInput != null)
        {
            Vector3 readMoveValue = _playerInput.MouseLook;
            float mouseLookY = readMoveValue.y;
            float mouseLookX = readMoveValue.x;
            float lookMouseLeft = mouseLookX * _mouseSensitivity;
            float lookMouseUp = mouseLookY * _mouseSensitivity;
            _rotationX += lookMouseLeft;
            _rotationY += lookMouseUp;
        }

        Vector3 nextRotation = new Vector3(-_rotationY, _rotationX);

        _rotationY = Mathf.Clamp(_rotationY, _rotationYMinMax.x, _rotationYMinMax.y);

        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);


        transform.localEulerAngles = _currentRotation;
        transform.position = _targetOfCamera.position - transform.forward * _distanceFromTarget;

        RaycastHit hit;
        if (Physics.Raycast(_targetOfCamera.position, transform.position - _targetOfCamera.position, out hit, Vector3.Distance(transform.position, _targetOfCamera.position), _maskObstacles))
        {
            transform.position = hit.point;
        }
    }
}
