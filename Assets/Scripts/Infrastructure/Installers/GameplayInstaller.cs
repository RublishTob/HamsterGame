using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private InputHandler input;
    [SerializeField] private LevelStateMachine _levelStateMachine;
    [SerializeField] private GlobalEventState _stateMachineView;
    [SerializeField] private SoundGamePlay soundGameplay;
    [SerializeField] private LevelProgressWatcher levelProgressWatcher;
    public override void InstallBindings()
    {
        Container.Bind<GlobalEventState>().FromInstance(_stateMachineView).AsSingle();
        Container.BindInterfacesAndSelfTo<WalletRepository>().AsSingle();
        Container.Bind<InputPlayer>().AsSingle();
        Container.Bind<SoundGamePlay>().FromInstance(soundGameplay).AsSingle();
        Container.Bind<RewardFactory>().AsSingle();

        Container.Bind<StartLevel>().AsSingle();
        Container.Bind<PauseLevel>().AsSingle();
        Container.Bind<LevelWin>().AsSingle();
        Container.Bind<LevelLoose>().AsSingle();

        Container.Bind<LevelStateMachine>().FromInstance(_levelStateMachine).AsSingle();
        Container.Bind<LevelProgressWatcher>().FromInstance(levelProgressWatcher).AsSingle();
        Container.Bind<InputHandler>().FromInstance(input).AsSingle();
        Container.Bind<LevelStateFactory>().AsSingle();
    }
}
