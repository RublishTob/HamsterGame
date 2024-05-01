using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputHandler: MonoBehaviour 
{
    [SerializeField] private IMovable _movable;
    private InputPlayer _playerInput;
    private Vector2 _vectorOfInput;
    private Vector3 _vectorOfMove;
    public Vector3 MouseLook { get; private set; }

    [Inject]
    private void Construct(InputPlayer input)
    {
        _playerInput = input;
    }
    private void Start()
    {
        _playerInput.Mover.Jump.started += Jump;
        _movable = FindObjectOfType<Movable>();
    }
    private void Update()
    {
        _vectorOfInput = _playerInput.Mover.MoveWalk.ReadValue<Vector2>().normalized;
        _vectorOfMove = new Vector3(_vectorOfInput.x, 0, _vectorOfInput.y);
        Move();
        MouseLook = _playerInput.Mover.MouseLook.ReadValue<Vector2>();
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
    }
}

