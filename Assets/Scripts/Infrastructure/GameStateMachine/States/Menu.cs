
public class Menu : GameState
{
    private SceneLoader _sceneLoader;
    private UIFactory _uiFactory;
    private DisposeManager _disposeManager;
    private MouseVisible _mouse;
    public Menu(GameStateMachine stateMachine, SceneLoader sceneLoader, UIFactory uiFactory, DisposeManager disposeManager, MouseVisible mouse) : base(stateMachine)
    {
        _sceneLoader = sceneLoader;
        _uiFactory = uiFactory;
        _disposeManager = disposeManager;
        _mouse = mouse;
    }
    public override void Start()
    {
        _sceneLoader.LoadScene(1,OnLoad);
        _mouse.SetVisible(true);
    }

    private void OnLoad()
    {
    }
    public override void Update()
    {
    }
    public override void Exit()
    {
        _disposeManager.DisposeResourse();
    }
}
