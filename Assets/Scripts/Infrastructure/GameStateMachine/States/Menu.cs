
using System.Threading.Tasks;
using UnityEngine;

public class Menu : GameState
{
    private IDataProvider _dataProvider;
    private Logger _logger;
    private SceneLoader _sceneLoader;
    private UIFactory _uiFactory;
    private UIControllerFactory _controllerFactory;
    public Menu(GameStateMachine stateMachine, DataLocalProvider provider, Logger logger, SceneLoader sceneLoader, UIFactory uiFactory, UIControllerFactory controllerFactory) : base(stateMachine)
    {
        _sceneLoader = sceneLoader;
        _dataProvider = provider;
        _logger = logger;
        _uiFactory = uiFactory;
        _controllerFactory = controllerFactory;
    }
    public override void Start()
    {
        _sceneLoader.LoadScene(1,OnLoad);
    }

    private void OnLoad()
    {
        _uiFactory.CreateMenu(new Vector3(1, 1, 1));
        _uiFactory.CreateMenuPanels(new Vector3(2, 2, 1));
        _uiFactory.CreateButtonBackMenu();
        _uiFactory.CreateNavigationMenu(new Vector3(1, 3, 1));
    }

    public override void Update()
    {
    }
    public override void Exit()
    {
    }
}
