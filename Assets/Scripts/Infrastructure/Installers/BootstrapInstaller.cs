using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private GameStateMachine _stateMachine;
    [SerializeField] private ScreenLook _screenLook;
    [SerializeField] private UIFactory _uiFactory;
    public override void InstallBindings()
    {
        BindData();
        BindServices();
        BindGameStates();
        Container.Bind<GameStateMachine>().FromInstance(_stateMachine).AsSingle();
        BindFactories();
    }
    private void BindData()
    {
        Container.BindInterfacesAndSelfTo<PersistentData>().AsSingle();
        Container.BindInterfacesAndSelfTo<ConfigData>().AsSingle();
        Container.BindInterfacesAndSelfTo<DataLocalProvider>().AsSingle();
        Container.BindInterfacesAndSelfTo<AssetProvider>().AsSingle();
        Container.Bind<SaveLoadSystem>().AsSingle();
        Container.Bind<StateLevelData>().AsSingle();
    }
    private void BindServices()
    {
        Container.Bind<Logger>().FromNew().AsSingle();
        Container.Bind<InputPlayer>().AsSingle();
        Container.Bind<SceneLoader>().FromInstance(_sceneLoader).AsSingle();
        Container.Bind<UIRouter>().AsSingle();
        Container.BindInterfacesAndSelfTo<LocalizationSystem>().AsSingle();
        Container.Bind<SceneUnlocker>().AsSingle();
        Container.Bind<SoundSystem>().AsSingle();
        Container.Bind<MouseSystem>().AsSingle();
        Container.Bind<VideoSystem>().AsSingle();
        Container.Bind<LevelLoaderSystem>().AsSingle();
        Container.Bind<RewardSystem>().AsSingle();
        Container.Bind<LevelProgressService>().AsSingle();

        BindScreenResolution();

    }
    private void BindFactories()
    {
        Container.Bind<UIPresenterFactory>().AsSingle();
        Container.Bind<UIFactory>().FromInstance(_uiFactory).AsSingle();
    }
    private void BindGameStates() 
    {
        Container.Bind<InitializeGame>().FromNew().AsSingle();
        Container.Bind<Menu>().FromNew().AsSingle();
        Container.Bind<LoadLevelState>().FromNew().AsSingle();
        Container.Bind<GameLoopState>().FromNew().AsSingle();
        Container.Bind<GameStateFactory>().FromNew().AsSingle();
    }
    private void BindScreenResolution()
    {
        Container.Bind<ScreenLook>().FromInstance(_screenLook).AsSingle();
        Container.Bind<ScreenLookPresenter>().FromNew().AsSingle().NonLazy();
    }
}
