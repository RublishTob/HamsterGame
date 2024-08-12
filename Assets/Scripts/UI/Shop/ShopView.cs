using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopView : MonoBehaviour
{
    private const string ID_BUTTON_SELECT = "Select";
    private const string ID_BUTTON_SELECTED = "Selected";

    [SerializeField] public Button _selectionButton;
    [SerializeField] public BuyButton _buyButton;
    [SerializeField] private Image _selectedImage;
    [SerializeField] private SkinPlacement _placement;

    [SerializeField] private TMP_Text selectText;
    [SerializeField] private TMP_Text selectedText;

    private ShopPanel _shopPanel;
    private ShopItemPresenter _previewItem;
    private LocalizationSystem _localization;

    private void OnDisable()
    {
        _buyButton.Click -= OnBuyButtonClick;
        _selectionButton.onClick.RemoveListener(OnSelectedButtonClick);
        _shopPanel.OnViewClick -= ShowItem;
    }
    [Inject]
    public void Construct(ShopPanel shopPanel, LocalizationSystem localization)
    {
        _shopPanel = shopPanel;
        _localization = localization;
        selectedText.text = _localization.GetString(ID_BUTTON_SELECTED);
        selectText.text = _localization.GetString(ID_BUTTON_SELECT);
        _shopPanel.OnViewClick += ShowItem;
        _buyButton.Click += OnBuyButtonClick;
        _selectionButton.onClick.AddListener(OnSelectedButtonClick);
        ShowItem(shopPanel.PreviewItem);
    }
    private void ShowItem(ShopItemPresenter previewItem)
    {
        if(previewItem == null)
        {
            throw new ArgumentNullException("There is no presenter we can show");
        }
        _previewItem = previewItem;
        ShowModel(_previewItem.Model);
        SetPrice(_previewItem.Price);
        _shopPanel.Highlight(_previewItem);

        if (_previewItem.IsOpen)
        {
            if (_previewItem.IsSelected)
            {
                ShowSelectedImage();
                _shopPanel.Select(_previewItem);
            }
            else
            {
                ShowSelectionButton();
            }
        }
        else
        {
            ShowBuyButton();
            if (_previewItem.IsCanBuy)
            {
                _buyButton.Unlock();
            }
            else
            {
                _buyButton.Lock();
            }
        }

    }
    public void SetPrice(string price)
    {
        _buyButton.UpdatePrice(price);
    }
    private void OnBuyButtonClick()
    {
        _shopPanel.Buy(_previewItem);
        ShowSelectionButton();
        HideBuyButton();
        //HideSelectionButton();
    }
    private void OnSelectedButtonClick()
    {
        _shopPanel.Select(_previewItem);
        ShowSelectedImage();
        HideSelectionButton();
        HideBuyButton();
    }
    public void ShowModel(GameObject model)
    {
        _placement.IntantiateModel(model);
    }
    private void ShowSelectionButton()
    {
        _selectionButton.gameObject.SetActive(true);
        HideBuyButton();
        HideSelectedImage();
    }
    private void ShowSelectedImage()
    {
        _selectedImage.gameObject.SetActive(true);
        HideSelectionButton();
        HideBuyButton();
    }
    private void ShowBuyButton()
    {
        _buyButton.gameObject.SetActive(true);
        HideSelectedImage();
        HideSelectionButton();
    }
    private void HideBuyButton()
    {
        _buyButton.gameObject.SetActive(false);
    }
    private void HideSelectionButton()
    {
        _selectionButton.gameObject.SetActive(false);
    }
    private void HideSelectedImage()
    {
        _selectedImage.gameObject.SetActive(false);
    }
}
