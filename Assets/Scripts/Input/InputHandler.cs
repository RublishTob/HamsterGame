using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputHandler: MonoBehaviour 
{
    [SerializeField] private IMovable _movable;
    private InputPlayer _playerInput;
    private GlobalEventState _eventState;
    private Vector2 _vectorOfInput;
    private Vector3 _vectorOfMove;
    private bool _isStartedGame;
    public Vector3 MouseLook { get; private set; }

    [Inject]
    public void Construct(InputPlayer input, GlobalEventState eventState)
    {
        _playerInput = input;
        _eventState = eventState;
    }
    private void Start()
    {
        _playerInput.Mover.Jump.started += Jump;
        _movable = FindObjectOfType<Movable>();
        _eventState.IsPaused += Pause;
        _eventState.IsStarted += StartGame;
        _isStartedGame = true;
    }
    private void Update()
    {
        if(_isStartedGame)
        {
            _vectorOfInput = _playerInput.Mover.MoveWalk.ReadValue<Vector2>().normalized;
            _vectorOfMove = new Vector3(_vectorOfInput.x, 0, _vectorOfInput.y);
            Move();
            MouseLook = _playerInput.Mover.MouseLook.ReadValue<Vector2>();
        }
    }
    public void Pause()
    {
        _vectorOfInput = Vector2.zero;
        _vectorOfMove = Vector2.zero;
        MouseLook = Vector2.zero;
        _isStartedGame = false;
    }
    public void StartGame()
    {
        _isStartedGame = true;
    }
    private void Jump(InputAction.CallbackContext obj)
    {
        _movable.Jump();
    }
    private void Move()
    {
        _movable.ChangeHorizontalDirection(_vectorOfMove);
    }
    private void OnEnable()
    {
        _playerInput.Enable();
    }
    private void OnDisable()
    {
        _playerInput.Disable();
        _playerInput.Mover.Jump.started -= Jump;
        _eventState.IsPaused -= Pause;
    }
}

