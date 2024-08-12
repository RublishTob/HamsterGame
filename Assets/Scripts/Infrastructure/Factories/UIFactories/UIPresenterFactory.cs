using Zenject;

public class UIPresenterFactory
{
    private UIRouter _router;
    private ExitGame _exitGame;
    private LocalizationSystem _localization;
    private PersistentData _data;
    private SceneUnlocker _unlockScene;
    private SaveLoadSystem _saveSystem;
    private SceneLoader _sceneLoader;
    private StateLevelData _levelData;
    private IDataProvider _provider;
    private SoundSystem _soundSystem;
    private MouseSystem _mouseSystem;
    private VideoSystem _videoSystem;
    private IConfigData _iConfigData;
    private LevelLoaderSystem _levelLoaderSystem;
    private DiContainer _container;
    private GameStateMachine _gameStateMachine;
    private UIFactory _uiFactory;

    public UIPresenterFactory(
        UIRouter router,
        LocalizationSystem localization,
        PersistentData data,
        SceneUnlocker unlockScene,
        SaveLoadSystem saveSystem,
        SceneLoader sceneLoader,
        StateLevelData levelData,
        IDataProvider provider,
        SoundSystem soundSystem,
        MouseSystem mouseSystem,
        VideoSystem videoSystem,
        IConfigData iConfigData,
        LevelLoaderSystem levelLoaderSystem,
        DiContainer container,
        GameStateMachine gameStateMachine,
        ExitGame exitGame
        )
    {
        _router = router;
        _localization = localization;
        _data = data;
        _unlockScene = unlockScene;
        _saveSystem = saveSystem;
        _sceneLoader = sceneLoader;
        _levelData = levelData;
        _provider = provider;
        _soundSystem = soundSystem;
        _mouseSystem = mouseSystem;
        _videoSystem = videoSystem;
        _iConfigData = iConfigData;
        _levelLoaderSystem = levelLoaderSystem;
        _container = container;
        _gameStateMachine = gameStateMachine;
        _exitGame = exitGame;
    }

    public ButtonPresenter CreateButtonContoller(ButtonView view, string id)
    {
        if (id == "Shop")
        {
            ButtonPresenter shopButtonController = new ShopButtonPresenter(view,_sceneLoader, _localization, id, _gameStateMachine, _soundSystem);
            return shopButtonController;
        }
        else if (id == "ToMenu")
        {
            ButtonPresenter toMenuButtonController = new ToMainButtonPresenter(view, _localization, id, _router, _gameStateMachine, _soundSystem);
            return toMenuButtonController;
        }
        else if (id == "Exit")
        {
            ButtonPresenter toMenuButtonController = new ExitButtonPresenter(view, _localization, _exitGame, id, _soundSystem);
            return toMenuButtonController;
        }
        else
        {
            ButtonPresenter buttonController = new NavigateButtonPresenter(view, _soundSystem, _router, _localization, id);
            return buttonController;
        }
    }
    public SettingPanelPresenter CreateSettingsPanelContoller(SettingPanelView view)
    {
        SettingPanelPresenter panelController = new SettingPanelPresenter(view, _router, _localization, _data, _provider, _soundSystem, _mouseSystem, _videoSystem);
        return panelController;
    }
    public LoadPanelPresenter CreateLoadPanelContoller(LoadPanelView view)
    {
        LoadPanelPresenter panelController = new LoadPanelPresenter(view,_unlockScene,_saveSystem,_sceneLoader, _data, _router, _levelLoaderSystem, _gameStateMachine, _soundSystem, _localization);
        return panelController;
    }
    public SavePanelPresenter CreateSavePanelContoller(SavePanelView view)
    {
        SavePanelPresenter panelController = new SavePanelPresenter(view, _soundSystem, _saveSystem, _router, _levelData, _data, _localization);
        return panelController;
    }
    public GamePanelPresenter CreateGamePanelContoller(GamePanelView view)
    {
        GamePanelPresenter panelController = new GamePanelPresenter(view, _unlockScene, _saveSystem, _sceneLoader, _data, _router, _iConfigData, _levelLoaderSystem, _gameStateMachine, _localization, _soundSystem);
        return panelController;
    }
    public ResultPanelPresenter CreateResultPanelContoller(ResultPanelView view, ResultBackgroundContent content, bool isSuccess, string id)
    {
        ResultPanelPresenter panelController = new ResultPanelPresenter(view, _router, _levelLoaderSystem, _soundSystem, _levelData, _localization, content, _gameStateMachine, isSuccess, id);
        return panelController;
    }

}
