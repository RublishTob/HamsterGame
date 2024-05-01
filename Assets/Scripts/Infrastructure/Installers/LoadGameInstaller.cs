using Zenject;
using UnityEngine;

public class LoadGameInstaller : MonoInstaller
{
    [SerializeField] private InitializeButtonView _buttonContinius;
    [SerializeField] private GameStateLoader _gsmLoader;

    public override void InstallBindings()
    {
        Container.Bind<InitializeButtonView>().FromInstance(_buttonContinius).AsSingle();
        Container.Bind<InitializeButtonPresenter>().AsSingle().NonLazy();
        Container.Bind<GameStateLoader>().FromInstance(_gsmLoader).AsSingle();
    }
}
