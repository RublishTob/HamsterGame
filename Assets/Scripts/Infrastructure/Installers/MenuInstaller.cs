using Zenject;
using UnityEngine;

public class MenuInstaller : MonoInstaller
{
    [SerializeField] private MenuLayout _menuLayout;
    [SerializeField] private PanelLayout _panelLayout;

    [SerializeField] private SoundMenu _sound;
    [SerializeField] private ChangeVideo _videoPlayer;
    public override void InstallBindings()
    {
        Container.Bind<ChangeVideo>().FromInstance(_videoPlayer).AsSingle();
        Container.Bind<SoundMenu>().FromInstance(_sound).AsSingle();
        Container.Bind<SoundMenuPresenter>().AsSingle().NonLazy();
        Container.Bind<MenuLayout>().FromInstance(_menuLayout).AsSingle();
        Container.Bind<PanelLayout>().FromInstance(_panelLayout).AsSingle();
    }
}
