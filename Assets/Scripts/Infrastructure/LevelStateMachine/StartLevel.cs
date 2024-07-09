
using UnityEngine;
using UnityEngine.InputSystem;

public class StartLevel : LevelState
{
    private UIRouter _router;
    private InputPlayer _playerInput;
    private LevelStateMachine _stateMachine;
    public StartLevel(LevelStateMachine stateMachine, UIRouter router, InputPlayer playerInput) : base(stateMachine)
    {
        _router = router;
        _playerInput = playerInput;
        _stateMachine = stateMachine;
    }
    public override void Start()
    {
        _playerInput.Mover.MenuEnable.started += PauseGame;
        _router.HideAll();
        Debug.Log("START LEVEL STATE");
    }

    private void PauseGame(InputAction.CallbackContext context)
    {
        _stateMachine.SwichState<PauseLevel>();
    }

    public override void Update()
    {
        
    }
    public override void Exit()
    {
        _playerInput.Mover.MenuEnable.started -= PauseGame;
    }
}
