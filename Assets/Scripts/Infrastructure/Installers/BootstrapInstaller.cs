using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private SoundSystem _soundSystem;
    [SerializeField] private GameStateMachine _stateMachine;
    public override void InstallBindings()
    {
        Container.Bind<IPersistentData>().To<PersistentData>().FromNew().AsSingle();
        Container.Bind<Logger>().FromNew().AsSingle();
        Container.Bind<DataLocalProvider>().FromNew().AsSingle();
        Container.Bind<InputPlayer>().AsSingle();
        Container.Bind<SceneLoader>().FromInstance(_sceneLoader).AsSingle();
        Container.Bind<SoundSystem>().FromInstance(_soundSystem).AsSingle();
        Container.BindInterfacesAndSelfTo<AssetProvider>().AsSingle();
        Container.Bind<UIFactory>().AsSingle();

        Container.Bind<InitializeGame>().FromNew().AsSingle();
        Container.Bind<Menu>().FromNew().AsSingle();
        Container.Bind<GameStateFactory>().FromNew().AsSingle();

        Container.Bind<GameStateMachine>().FromInstance(_stateMachine).AsSingle();

    }
}
