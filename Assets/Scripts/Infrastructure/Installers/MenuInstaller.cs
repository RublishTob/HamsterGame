using System;
using Zenject;
using UnityEngine;

public class MenuInstaller : MonoInstaller
{
    [SerializeField] private SoundMenu _soundMenu;
    public override void InstallBindings()
    {
        Container.Bind<SoundMenu>().FromInstance(_soundMenu).AsSingle();
        Container.Bind<SoundMenuPresenter>().AsSingle().NonLazy();
    }
}
