using UnityEngine;
using Zenject;

public class ShopInstaller : MonoInstaller
{
    [SerializeField] private ShopView _shopView;
    [SerializeField] private WalletView _walletView;
    [SerializeField] private ShopPanel _shopPanel;
    [SerializeField] private MenuPanel _menu;

    [SerializeField] private ShopContent _shopContent;

    [SerializeField] private ItemViewFactory _viewfactory;
    public override void InstallBindings()
    {
        Container.Bind<Wallet>().AsSingle();
        Container.BindInterfacesAndSelfTo<WalletRepository>().AsSingle();

        Container.Bind<SkinUnlocker>().AsSingle();
        Container.Bind<OpenSkinChecker>().AsSingle();
        Container.Bind<SelectedSkinChecker>().AsSingle();
        Container.Bind<SkinSelector>().AsSingle();
        Container.Bind<ItemPresenterFactory>().AsSingle();


        Container.Bind<ShopContent>().FromInstance(_shopContent).AsSingle();
        Container.Bind<ItemViewFactory>().FromInstance(_viewfactory).AsSingle();
        Container.Bind<ShopPanel>().FromInstance(_shopPanel).AsSingle();
        Container.Bind<ShopView>().FromInstance(_shopView).AsSingle();

        Container.Bind<MenuPanel>().FromInstance(_menu).AsSingle();
    }
}
