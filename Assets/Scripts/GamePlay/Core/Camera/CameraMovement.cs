using UnityEngine;
using Zenject;
using UniRx;

public class CameraMovement: MonoBehaviour
{
    private PlayerViewDetect _target;
    private SaveLoadSystem _saveLoadSystem;
    private StateLevelData _stateLevelData;
    private MouseSystem _mouseSense;
    private GlobalEventState _globalEventState;

    private Transform _targetOfCamera;
    [SerializeField] private InputHandler _playerInput;

    [SerializeField] private Vector2 _rotationYMinMax;
    [SerializeField] private LayerMask _maskObstacles;

    private float _mouseSensitivity = 0.1f;
    private float _tempSensitivity;
    [SerializeField] private float _distanceFromTarget = 3.0f;
    [SerializeField] private float _smoothTime = 0.2f;

    private float _rotationClamp = 40;
    private float _rotationX;
    private float _rotationY;

    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;

    CompositeDisposable _compositeDisposable = new CompositeDisposable();

    [Inject]
    public void Construct(SaveLoadSystem saveLoadSystem, StateLevelData stateLevelData, MouseSystem mouse, GlobalEventState globalEventState)
    {
        _saveLoadSystem = saveLoadSystem;
        _stateLevelData = stateLevelData;
        _mouseSense = mouse;
        _globalEventState = globalEventState;
        _globalEventState.IsPaused += PauseLevel;
        _globalEventState.IsStarted += StartLevel;
        ChangeMouseSense(_mouseSense.MouseSense.Value);
        _mouseSense.MouseSense.Subscribe(sense =>
        {
            ChangeMouseSense(sense);

        }).AddTo(_compositeDisposable);


        _saveLoadSystem.SaveData += SaveRotation;
        LoadRotation();
    }
    private void PauseLevel ()
    {
        _tempSensitivity = _mouseSensitivity;
        _mouseSensitivity = 0f;
    }
    private void StartLevel()
    {
        _mouseSensitivity = _tempSensitivity;
    }
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

    private void ChangeMouseSense(float mouseSense)
    {
        _mouseSensitivity = mouseSense;
    }

    private void LoadRotation()
    {
        _rotationY = (float)_stateLevelData.CameraRot_Y;
        _rotationX = (float)_stateLevelData.CameraRot_X;
        _currentRotation = new Vector3(-_rotationY, _rotationX);
    }
    private void SaveRotation()
    {
        _stateLevelData.CameraRot_X = _rotationX;
        _stateLevelData.CameraRot_Y = _rotationY;
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
    private void OnDisable()
    {
        _globalEventState.IsPaused -= PauseLevel;
        _saveLoadSystem.SaveData -= SaveRotation;
        _globalEventState.IsStarted -= StartLevel;
        _compositeDisposable.Dispose();
    }
}
