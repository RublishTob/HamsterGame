using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ShopPanel : MonoBehaviour
{
    private const string ID_BUTTON_CHARACTERS = "Characters";
    private const string ID_BUTTON_HOUSES = "Houses";
    private const string ID_BUTTON_SELECTED = "Selected";

    public event Action<ShopItemPresenter> OnViewClick;

    [SerializeField] private ShopCategoryButton _characterSkinButton;
    [SerializeField] private ShopCategoryButton _houseSkinButton;
    [SerializeField] private Transform _itemParents;

    private List<ShopItemPresenter> _shopItems;

    private ShopItemPresenter _previewItem;
    private LocalizationSystem _localization;
    private ShopContent _contentItems;
    private ItemViewFactory _factoryView;
    private ItemPresenterFactory _factoryPresenter;

    [Inject]
    public void Construct(ShopContent contentItems, ItemViewFactory factoryView, ItemPresenterFactory factoryPresenter, LocalizationSystem localization)
    {
        _factoryView = factoryView;
        _factoryPresenter = factoryPresenter;
        _contentItems = contentItems;
        _localization = localization;
        _shopItems = new();

        _characterSkinButton.Click += OnCharacterSkinsButtonClick;
        _houseSkinButton.Click += OnHouseSkinsButtonClick;
        _houseSkinButton.SetText(_localization.GetString(ID_BUTTON_HOUSES));
        _characterSkinButton.SetText(_localization.GetString(ID_BUTTON_CHARACTERS));

        OnHouseSkinsButtonClick();
    }
    private void OnDisable()
    {
        _characterSkinButton.Click -= OnCharacterSkinsButtonClick;
        _houseSkinButton.Click -= OnHouseSkinsButtonClick;
    }
    public ShopItemPresenter PreviewItem 
    { 
        get { return _previewItem; } 
    }
    private void OnCharacterSkinsButtonClick()
    {
        _characterSkinButton.Select();
        _houseSkinButton.UnSelect();
        Create(_contentItems.CharacterSkinItems);
    }
    private void OnHouseSkinsButtonClick()
    {
        _houseSkinButton.Select();
        _characterSkinButton.UnSelect();
        Create(_contentItems.HouseSkinItems);
    }
    public void Select(ShopItemPresenter item)
    {
        foreach (var spawnedItem in _shopItems)
        {
            spawnedItem.UnSelected();
        }
        item.Selected();
    }
    public void Buy(ShopItemPresenter item)
    {
        item.TryToBuy();
    }
    public void Highlight(ShopItemPresenter item)
    {
        foreach (var obj in _shopItems)
            obj.UnHighlight();

        item.Highlight();
    }
    private void Create(IEnumerable<ShopItem> items)
    {
        int itemPrewied = UnityEngine.Random.Range(0,items.Count());

        Clear();
        foreach(ShopItem item in items)
        {
            ShopItemView spawnedItem = Instantiate(_factoryView.Get(item), _itemParents);
            spawnedItem.SetText(_localization.GetString(ID_BUTTON_SELECTED));
            ShopItemPresenter presenter = _factoryPresenter.Get(item, spawnedItem);
            presenter.Click += PrewiedItem;
            presenter.UnSelected();
            presenter.UnHighlight();
            presenter.Update();
            presenter.Enable();
            _shopItems.Add(presenter);
        }
        Debug.Log($"ñåé÷àñ â ñïèñêå {_shopItems.Count} ýëåìåíòîâ");
        PrewiedItem(_shopItems[itemPrewied]);
        Sort();
    }
    private void PrewiedItem(ShopItemPresenter presenter)
    {
        if(_previewItem == presenter) 
            return;

        OnViewClick?.Invoke(presenter);
        _previewItem = presenter;
        Highlight(_previewItem);
    }
    private void Sort()
    {
        _shopItems = _shopItems
            .OrderBy(item => item.IsOpen)
            .ThenByDescending(item => item.Price)
            .ToList();
        for (int i = 0; i < _shopItems.Count; i++)
        {
            //_shopItems[i].transform.SetSiblingIndex(i);
            //ÄÎÄÅËÀÒÜ ÑÎÐÒÈÐÎÂÊÓ
        }
    }
    private void Clear()
    {
        for (int i = 0; i < _shopItems.Count; i++)
        {
            _shopItems[i].Click -= PrewiedItem;
            _shopItems[i].Disable();
        }
        _shopItems.Clear();
    }
}
