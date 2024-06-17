
using UnityEngine;

public class GameLoopState : GameState
{
    private UIFactory _uiFactory;
    public GameLoopState(GameStateMachine stateMachine, UIFactory uiFactory) : base(stateMachine)
    {
        _uiFactory = uiFactory;
    }

    public override void Exit()
    {
        //Debug.Log("GameLoopStateExit");
    }

    public override void Start()
    {
        //Debug.Log("GameLoopStateStart");
    }

    public override void Update()
    {
        //Debug.Log("GameLoopStateUpdate");
    }
}
