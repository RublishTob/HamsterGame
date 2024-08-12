using UnityEngine;

public class ShopBootstrap : MonoBehaviour
{
    [SerializeField] private ShopView _shopView;
    [SerializeField] private WalletView _walletView;
    [SerializeField] private ShopContent _shopContent;
    [SerializeField] private ShopPanel _shopPanel;
    [SerializeField] private ItemViewFactory _viewfactory;


    public void Awake()
    {
        InitializeShop();
    }

    private void InitializeShop()
    {
        //_shopPanel.Construct(_shopContent, _viewfactory, factoryPresenters);
        //_shopView.Construct(_shopPanel);
    }
}
