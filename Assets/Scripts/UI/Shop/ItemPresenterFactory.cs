
public class ItemPresenterFactory
{
    private OpenSkinChecker _openSkinChecker;
    private SelectedSkinChecker _selectedSkinChecker;
    private SkinSelector _skinSelector;
    private SkinUnlocker _skinUnlocker;
    private IDataProvider _dataProvider;
    private Wallet _wallet;

    public ItemPresenterFactory(OpenSkinChecker openSkinChecker, SelectedSkinChecker selectedSkin, SkinSelector skinSelector, SkinUnlocker skinUnlocker, IDataProvider dataProvider, Wallet wallet)
    {
        _openSkinChecker = openSkinChecker;
        _selectedSkinChecker = selectedSkin;
        _skinSelector = skinSelector;
        _skinUnlocker = skinUnlocker;
        _dataProvider = dataProvider;
        _wallet = wallet;
    }

    public ShopItemPresenter Get(ShopItem model, ShopItemView view)
    {
        ShopItemPresenter presenter = new ShopItemPresenter(model, view, _openSkinChecker, _selectedSkinChecker, _skinSelector, _skinUnlocker, _dataProvider, _wallet);
        return presenter;
    }

}
