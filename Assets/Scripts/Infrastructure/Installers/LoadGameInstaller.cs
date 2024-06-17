using Zenject;
using UnityEngine;

public class LoadGameInstaller : MonoInstaller
{
    [SerializeField] private ButtonView _buttonContinius;

    public override void InstallBindings()
    {
        Container.Bind<ButtonView>().FromInstance(_buttonContinius).AsTransient();
        Container.Bind<InitializeButtonPresenter>().AsSingle().NonLazy();
        Container.Bind<SoundSystemView>().AsSingle();
    }
}
