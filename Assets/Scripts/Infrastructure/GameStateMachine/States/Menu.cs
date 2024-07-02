
using UnityEngine;

public class Menu : GameState
{
    private SceneLoader _sceneLoader;
    public Menu(GameStateMachine stateMachine, SceneLoader sceneLoader) : base(stateMachine)
    {
        _sceneLoader = sceneLoader;
    }
    public override void Start()
    {
        _sceneLoader.LoadScene(1,OnLoad);
    }

    private void OnLoad()
    {
    }
    public override void Update()
    {
    }
    public override void Exit()
    {
    }
}
