using UnityEngine;

public class ShopBootstrap : MonoBehaviour
{
    //[SerializeField] private ShopView _shopView;
    //[SerializeField] private WalletView _walletView;
    //[SerializeField] private ShopContent _shopContent;
    //[SerializeField] private ShopPanel _shopPanel;
    //[SerializeField] private ItemViewFactory _viewfactory;

    //private IDataProvider _dataProvider;
    //private IPersistentData _persistentPlayerData;

    //private Wallet _wallet;

    //public void Awake()
    //{
    //    InitializeData();
    //    InitializeWallet();
    //    InitializeShop();
    //}
    //private void InitializeData()
    //{
    //    _persistentPlayerData = new PersistentData();
    //    _dataProvider = new DataLocalProvider(_persistentPlayerData);
    //    LoadDataOrCreate();
    //}
    //private void InitializeWallet()
    //{
    //    _wallet = new Wallet(_persistentPlayerData);
    //    _walletView.Construct(_wallet);
    //}

    //private void InitializeShop()
    //{
    //    OpenSkinChecker openSkinChecker = new OpenSkinChecker(_persistentPlayerData);
    //    SelectedSkinChecker selectedSkinChecker = new SelectedSkinChecker(_persistentPlayerData);
    //    SkinSelector skinSelector = new SkinSelector(_persistentPlayerData);
    //    SkinUnlocker skinUnlocker = new SkinUnlocker(_persistentPlayerData);
    //    ItemPresenterFactory factoryPresenters = new ItemPresenterFactory(openSkinChecker, selectedSkinChecker, skinSelector, skinUnlocker, _dataProvider, _wallet);
    //    _shopPanel.Construct(_shopContent, _viewfactory, factoryPresenters);
    //    _shopView.Construct(_shopPanel);
    //}
    //private void LoadDataOrCreate()
    //{
    //    if(_dataProvider.TryLoad() == false)
    //    {
    //        _persistentPlayerData.PlayerData = new PlayerData();
    //    }
    //}
}
