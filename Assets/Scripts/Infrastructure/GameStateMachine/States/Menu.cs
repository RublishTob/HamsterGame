
using UnityEngine;

public class Menu : GameState
{
    private SceneLoader _sceneLoader;
    private UIFactory _uiFactory;
    public Menu(GameStateMachine stateMachine, SceneLoader sceneLoader, UIFactory uiFactory) : base(stateMachine)
    {
        _sceneLoader = sceneLoader;
        _uiFactory = uiFactory;
    }
    public override void Start()
    {
        _sceneLoader.LoadScene(1,OnLoad);
    }

    private void OnLoad()
    {
        _uiFactory.CreateRoot(new Vector3(1, 1, 1));
        _uiFactory.CreatePanelsRoot();
        _uiFactory.CreateMenuRoot();
    }

    public override void Update()
    {
    }
    public override void Exit()
    {
    }
}
