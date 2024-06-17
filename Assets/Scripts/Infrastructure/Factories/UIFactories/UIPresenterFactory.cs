
using System.ComponentModel;
using Zenject;

public class UIPresenterFactory
{
    private UIRouter _router;
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
        GameStateMachine gameStateMachine
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

    }
    public NavigateButtonPresenter CreateButtonContoller(ButtonView view, string id)
    {
        NavigateButtonPresenter buttonController = new NavigateButtonPresenter(view, _router,_localization, id);

        return buttonController;
    }
    public SettingPanelPresenter CreateSettingsPanelContoller(SettingPanelView view)
    {
        SettingPanelPresenter panelController = new SettingPanelPresenter(view, _router, _localization, _data, _provider, _soundSystem, _mouseSystem, _videoSystem);
        return panelController;
    }
    public LoadPanelPresenter CreateLoadPanelContoller(LoadPanelView view)
    {
        LoadPanelPresenter panelController = new LoadPanelPresenter(view,_unlockScene,_saveSystem,_sceneLoader, _data, _router, _levelLoaderSystem, _gameStateMachine);
        return panelController;
    }
    public SavePanelPresenter CreateSavePanelContoller(SavePanelView view)
    {
        SavePanelPresenter panelController = new SavePanelPresenter(view, _saveSystem, _router, _levelData, _data);
        return panelController;
    }
    public GamePanelPresenter CreateGamePanelContoller(GamePanelView view)
    {
        GamePanelPresenter panelController = new GamePanelPresenter(view, _unlockScene, _saveSystem, _sceneLoader, _data, _router, _iConfigData, _levelLoaderSystem, _gameStateMachine);
        return panelController;
    }

}
