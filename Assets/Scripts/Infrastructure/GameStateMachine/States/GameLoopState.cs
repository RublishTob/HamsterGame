
using UnityEngine;

public class GameLoopState : GameState
{
    private UIFactory _uiFactory;
    private UIRouter _router;
    public GameLoopState(GameStateMachine stateMachine, UIFactory uiFactory, UIRouter router) : base(stateMachine)
    {
        _uiFactory = uiFactory;
        _router = router;
    }

    public override void Exit()
    {
    }

    public override void Start()
    {
    }

    public override void Update()
    {
    }
}
