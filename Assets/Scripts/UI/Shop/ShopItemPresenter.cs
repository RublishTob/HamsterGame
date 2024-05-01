using System;
using UnityEngine;

public class ShopItemPresenter
{
    public event Action<ShopItemPresenter> Click;

    private ShopItemView _shopItemView;
    private ShopItem _shopItemModel;

    private OpenSkinChecker _openSkinChecker;
    private SelectedSkinChecker _selectedSkinChecker;
    private SkinSelector _skinSelector;
    private SkinUnlocker _skinUnlocker;
    private IDataProvider _dataProvider;
    private Wallet _wallet;
    public ShopItemPresenter(ShopItem model, ShopItemView shopItemView, OpenSkinChecker openSkinChecker, SelectedSkinChecker selectedSkin, SkinSelector skinSelector, SkinUnlocker skinUnlocker, IDataProvider dataProvider, Wallet wallet)
    {
        _shopItemModel = model;
        _shopItemView = shopItemView;
        _openSkinChecker = openSkinChecker;
        _selectedSkinChecker = selectedSkin;
        _skinSelector = skinSelector;
        _skinUnlocker = skinUnlocker;

        _dataProvider = dataProvider;
        _wallet = wallet;
    }
    public bool IsOpen { get; private set; }
    public bool IsSelected { get; private set; }
    public bool IsCanBuy { get; private set; }

    public GameObject Model => _shopItemModel.Model;
    public string Price => _shopItemModel.Price.ToString();
    public Sprite ContentImage => _shopItemModel.ContentImage;
    public void Enable()
    {
        _shopItemView.SetContentImage(_shopItemModel.ContentImage);
        _shopItemView.SetPrice(_shopItemModel.Price.ToString());
        _shopItemView.OnViewClicked += OnViewClick;
        _shopItemView.gameObject.SetActive(true);
    }
    public void Disable()
    {
        _shopItemView.OnViewClicked -= OnViewClick;
        _shopItemView.Disable();
    }
    public void OnViewClick()
    {
        Click?.Invoke(this);
    }
    public void TryToBuy()
    {
        if (IsOpen)
            return;
        if (_wallet.IsEnough(_shopItemModel.Price))
        {
            Unlock();
            BuyItem();
            _dataProvider.Save();
        }
    }
    public void Update()
    {
        _openSkinChecker.Visit(_shopItemModel);
        if (_openSkinChecker.IsOpen)
        {
            Unlock();
            _selectedSkinChecker.Visit(_shopItemModel);
            if (_selectedSkinChecker.IsSelected)
            {
                Selected();
                return;
            }
            UnSelected();
        }
        else
        {
            Lock();
            if (_wallet.IsEnough(_shopItemModel.Price))
            {
                IsCanBuy = true;
            }
            else
            {
                IsCanBuy = false;
            }
        }
    }
    public void Selected()
    {
        IsSelected = true;
        _shopItemView.Selected(true);
        _skinSelector.Visit(_shopItemModel);
        _dataProvider.Save();
    }
    public void UnSelected()
    {
        IsSelected = false;
        _shopItemView.Selected(false);
        _dataProvider.Save();
    }
    public void Highlight()
    {
        _shopItemView.Highlight(true);
    }
    public void UnHighlight()
    {
        _shopItemView.Highlight(false);
    }
    private void BuyItem()
    {
        _wallet.Spend(_shopItemModel.Price);
        Unlock();
        _skinUnlocker.Visit(_shopItemModel);
        _dataProvider.Save();
    }
    private void Lock()
    {
        _shopItemView.Locked(true);
        IsOpen = false;
    }
    private void Unlock()
    {
        _shopItemView.Locked(false);
        IsOpen = true;
    }
}
