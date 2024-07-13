
public class Menu : GameState
{
    private SceneLoader _sceneLoader;
    private UIFactory _uiFactory;
    private GameStateMachineService _gameStateMachineService;
    public Menu(GameStateMachine stateMachine, SceneLoader sceneLoader, UIFactory uiFactory, GameStateMachineService gameStateMachineService) : base(stateMachine)
    {
        _sceneLoader = sceneLoader;
        _uiFactory = uiFactory;
        _gameStateMachineService = gameStateMachineService;
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
        _gameStateMachineService.GameStateWacher.ChangeState();
    }
}
