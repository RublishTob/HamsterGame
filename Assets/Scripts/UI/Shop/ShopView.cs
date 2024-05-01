using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour
{
    [SerializeField] public Button _selectionButton;
    [SerializeField] public BuyButton _buyButton;
    [SerializeField] private Image _selectedImage;
    [SerializeField] private SkinPlacement _placement;

    private ShopPanel _shopPanel;
    private ShopItemPresenter _previewItem;

    private void OnDisable()
    {
        _buyButton.Click -= OnBuyButtonClick;
        _selectionButton.onClick.RemoveListener(OnSelectedButtonClick);
        _shopPanel.OnViewClick -= ShowItem;
    }
    public void Construct(ShopPanel shopPanel)
    {
        _shopPanel = shopPanel;
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
        ShowSelectedImage();
        HideBuyButton();
        HideSelectionButton();
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
