using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<WalletRepository>().AsSingle();
        Container.Bind<InputPlayer>().AsSingle();
        //Container.Bind<LevelProgressWatcher>().AsSingle().NonLazy();
    }
}
