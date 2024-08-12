using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class Movable : MonoBehaviour, IMovable
{
    private const string MOVE = "MoveFwd";

    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpForce = 30f;

    private CharacterController _characterController;
    private PlayerView _playerView;
    private PlayerViewDetect _playerViewDetect;
    private Camera _camera;
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _groundClip;
    [SerializeField] private AudioClip _waterClip;

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
        _audioSource = GetComponent<AudioSource>();
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
        if (_playerViewDetect.IsWater)
        {
            IsWater(true);
        }
        else
        {
            IsWater(false);
        }
    }
    public void ChangeHorizontalDirection(Vector3 moveDirection)
    {
        _movement = moveDirection;
    }
    private void IsWater(bool isWater)
    {
        if (isWater)
        {
            _audioSource.clip = _waterClip;
        }
        else
        {
            _audioSource.clip = _groundClip;
        }
    }
    private void Move()
    {
        Quaternion cameraDirection = Quaternion.Euler(0, _cameraRotation, 0);
        _rotatedMovement = cameraDirection * _movement.normalized;
        _verticalMovement = _jumpVector * _mSpeedY;
        if (RotatedMovement.x != 0 || RotatedMovement.z != 0)
        {
            _playerView.SetAnimatorBool(MOVE, true);
        }
        else
        {
            _playerView.SetAnimatorBool(MOVE, false);
        }
        _characterController.Move((_verticalMovement + _rotatedMovement * _speed) * Time.deltaTime);
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
    public void FootStep()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
    }
}
