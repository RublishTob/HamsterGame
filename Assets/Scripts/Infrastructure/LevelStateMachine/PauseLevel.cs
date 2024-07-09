using UnityEngine;
using UnityEngine.InputSystem;

public class PauseLevel : LevelState
{
    private UIRouter _router;
    private InputPlayer _playerInput;
    private LevelStateMachine _stateMachine;
    private GlobalEventState _globalEvent;
    public PauseLevel(LevelStateMachine stateMachine, UIRouter router, InputPlayer playerInput, GlobalEventState stateMachineView) : base(stateMachine)
    {
        _router = router;
        _playerInput = playerInput;
        _stateMachine = stateMachine;
        _globalEvent = stateMachineView;
    }

    public override void Start()
    {
        _playerInput.Mover.MenuEnable.started += StartLevel;
        _router.OpenMenu("NewGamePanel");
        _globalEvent.PauseGame();
        Debug.Log("PAUSE LEVEL STATE");
    }
    public override void Exit()
    {
        _globalEvent.StartGame();
        _playerInput.Mover.MenuEnable.started -= StartLevel;
    }

    private void StartLevel(InputAction.CallbackContext context)
    {
        _stateMachine.SwichState<StartLevel>();
    }

    public override void Update()
    {
    }
}
