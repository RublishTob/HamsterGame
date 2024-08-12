using UnityEngine;
using UnityEngine.InputSystem;

public class PauseLevel : LevelState
{
    private UIRouter _router;
    private InputPlayer _playerInput;
    private LevelStateMachine _stateMachine;
    private GlobalEventState _globalEvent;
    private MouseVisible _mouse;
    private Counter _counter;
    public PauseLevel(LevelStateMachine stateMachine, UIRouter router, InputPlayer playerInput, GlobalEventState stateMachineView, MouseVisible mouse, Counter counter) : base(stateMachine)
    {
        _router = router;
        _playerInput = playerInput;
        _stateMachine = stateMachine;
        _globalEvent = stateMachineView;
        _mouse = mouse;
        _counter = counter;
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
        Debug.Log("NOTPAUSE LEVEL STATE");
        _globalEvent.StartGame();
        _counter.StartTimer();
        _playerInput.Mover.MenuEnable.started -= StartLevel;
    }

    private void StartLevel(InputAction.CallbackContext context)
    {
        _mouse.SetVisible(false);
        _stateMachine.SwichState<StartLevel>();
    }

    public override void Update()
    {
    }
}
