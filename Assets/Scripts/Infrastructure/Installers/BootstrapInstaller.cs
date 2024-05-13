using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private SoundSystem _soundSystem;
    [SerializeField] private GameStateMachine _stateMachine;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PersistentData>().AsSingle();
        Container.Bind<Logger>().FromNew().AsSingle();

        Container.BindInterfacesAndSelfTo<DataLocalProvider>().AsSingle();
        Container.Bind<InputPlayer>().AsSingle();
        Container.Bind<SceneLoader>().FromInstance(_sceneLoader).AsSingle();
        Container.Bind<SoundSystem>().FromInstance(_soundSystem).AsSingle();
        Container.BindInterfacesAndSelfTo<AssetProvider>().AsSingle();
        Container.Bind<UIRouter>().AsSingle();
        Container.BindInterfacesAndSelfTo<Localization>().AsSingle();

        Container.Bind<UIPresenterFactory>().AsSingle();
        Container.Bind<UIFactory>().AsSingle();

        Container.Bind<InitializeGame>().FromNew().AsSingle();
        Container.Bind<Menu>().FromNew().AsSingle();
        Container.Bind<GameStateFactory>().FromNew().AsSingle();

        Container.Bind<GameStateMachine>().FromInstance(_stateMachine).AsSingle();

    }
}
