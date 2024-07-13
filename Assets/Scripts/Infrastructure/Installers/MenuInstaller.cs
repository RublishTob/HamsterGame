using System;
using Zenject;
using UnityEngine;
using UnityEngine.Video;

public class MenuInstaller : MonoInstaller
{
    [SerializeField] private SoundMenu _sound;
    [SerializeField] private GameStateWacher _stateWatcher;
    //[SerializeField] private ChangeVideo _videoPlayer;
    public override void InstallBindings()
    {
        //Container.Bind<ChangeVideo>().FromInstance(_videoPlayer).AsSingle();
        Container.Bind<SoundMenu>().FromInstance(_sound).AsSingle();
        Container.Bind<SoundMenuPresenter>().AsSingle().NonLazy();
        Container.Bind<GameStateWacher>().FromInstance(_stateWatcher).AsSingle();
    }
}
