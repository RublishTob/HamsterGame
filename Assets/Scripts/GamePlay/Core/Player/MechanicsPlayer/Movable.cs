using UnityEngine;

public class Movable : MonoBehaviour, IMovable
{
    private const string MOVE = "MoveFwd";

    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpForce = 20f;

    private CharacterController _characterController;
    private PlayerView _playerView;
    private PlayerViewDetect _playerViewDetect;
    private Camera _camera;

    private float _mGravity = -10f;
    private float _cameraRotation;
    private float _mSpeedY = 0;

    private Vector3 _movement;
    private Vector3 _jumpVector;
    private Vector3 _verticalMovement;
    private Vector3 _rotatedMovement;
    public Vector3 RotatedMovement { get => _rotatedMovement; }

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _playerView = GetComponent<PlayerView>();
        _playerViewDetect = GetComponent<PlayerViewDetect>();
        _camera = FindObjectOfType<Camera>();
        _jumpVector = Vector3.up;
        _movement = Vector3.zero;
    }
    private void Update()
    {
        _cameraRotation = _camera.transform.rotation.eulerAngles.y;
        Gravity();
        Move();
    }
    public void ChangeHorizontalDirection(Vector3 moveDirection)
    {
        _movement = moveDirection;
    }
    private void Move()
    {
        Quaternion cameraDirection = Quaternion.Euler(0, _cameraRotation, 0);
        _rotatedMovement = cameraDirection * _movement.normalized;
        _verticalMovement = _jumpVector * _mSpeedY;
        _characterController.Move((_verticalMovement + _rotatedMovement * _speed) * Time.deltaTime);
        if (RotatedMovement.x != 0 || RotatedMovement.z != 0)
        {
            _playerView.SetAnimatorBool(MOVE, true);
        }
        else
        {
            _playerView.SetAnimatorBool(MOVE, false);

        }
    }
    public void Jump()
    {
        if(_playerViewDetect.IsOnGround)
        _mSpeedY += _jumpForce;
    }
    private void Gravity()
    {
        if (_playerViewDetect.IsOnGround && _mSpeedY < 0)
        {
            _mSpeedY = 0f;
        }
        else if (!_playerViewDetect.IsOnGround)
        {
            _mSpeedY += _mGravity * 5 * Time.deltaTime;
        }
    }

}
