using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private InputHandler _input;
    [SerializeField] private MenuLayout _menuLayout;
    [SerializeField] private PanelLayout _panelLayout;
    [SerializeField] private Counter _counter;
    [SerializeField] private TutorialText _tutorialText;
    [SerializeField] private LevelStateMachine _levelStateMachine;
    [SerializeField] private GlobalEventState _stateMachineView;
    [SerializeField] private SoundGamePlay _soundGameplay;
    [SerializeField] private SoundResultGame _soundResultGame;
    [SerializeField] private LevelProgressWatcher _levelProgressWatcher;
    public override void InstallBindings()
    {
        Container.Bind<GlobalEventState>().FromInstance(_stateMachineView).AsSingle();
        Container.BindInterfacesAndSelfTo<WalletRepository>().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerPresenter>().AsSingle();
        Container.Bind<InputPlayer>().AsSingle();
        Container.Bind<SoundGamePlay>().FromInstance(_soundGameplay).AsSingle();
        Container.Bind<SoundGamePlayPresenter>().AsSingle().NonLazy();
        Container.Bind<Counter>().FromInstance(_counter).AsSingle();
        Container.Bind<TutorialText>().FromInstance(_tutorialText).AsSingle();
        Container.Bind<MenuLayout>().FromInstance(_menuLayout).AsSingle();

        Container.Bind<SoundResultGame>().FromInstance(_soundResultGame).AsSingle();

        Container.Bind<PanelLayout>().FromInstance(_panelLayout).AsSingle();
        Container.Bind<RewardFactory>().AsSingle();

        Container.Bind<StartLevel>().AsSingle();
        Container.Bind<TutorialLevel>().AsSingle();
        Container.Bind<PauseLevel>().AsSingle();
        Container.Bind<LevelWin>().AsSingle();
        Container.Bind<LevelLoose>().AsSingle();

        Container.Bind<LevelStateMachine>().FromInstance(_levelStateMachine).AsSingle();
        Container.Bind<LevelProgressWatcher>().FromInstance(_levelProgressWatcher).AsSingle();
        Container.Bind<InputHandler>().FromInstance(_input).AsSingle();
        Container.Bind<LevelStateFactory>().AsSingle();
    }
}
