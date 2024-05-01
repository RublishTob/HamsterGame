
using UnityEngine;

public class LoadLevel : GameState
{
    private UIFactory _uiFactory;
    public LoadLevel(GameStateMachine stateMachine, UIFactory uIFactory) : base(stateMachine)
    {
        _uiFactory = uIFactory;
    }
    public override void Start()
    {
        var loadBar = _uiFactory.CreateLoadBar(new Vector3(2, 2, 1));
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
    public override void Exit()
    {
        throw new System.NotImplementedException();
    }
}
