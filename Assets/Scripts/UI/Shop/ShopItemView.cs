using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour, IPointerClickHandler
{
    public event Action OnViewClicked;

    [SerializeField] private Image _selectionImage;
    [SerializeField] private Image _lockImage;
    [SerializeField] private ValueView _price;

    [SerializeField] private Sprite _standartBackground;
    [SerializeField] private Sprite _highlightBackground;

    [SerializeField] private Image _contentImage;
    [SerializeField] private Image _backgroundImage;
    public void OnPointerClick(PointerEventData eventData)
    {
        OnViewClicked?.Invoke();
    }
    public void OnEnable()
    {
        _backgroundImage = GetComponent<Image>();
        _backgroundImage.sprite = _standartBackground;
    }
    public void Enable()
    {
        gameObject.SetActive(true);
    }
    public void Disable()
    {
        Destroy(gameObject);
    }
    public void SetContentImage(Sprite contentImage)
    {
        _contentImage.sprite = contentImage;
    }
    public void SetPrice(string price)
    {
        _price.SetPrice(price);
    }
    public void Locked(bool isLocked)
    {
        _lockImage.gameObject.SetActive(isLocked);
        if (isLocked)
        {
            _price.Show();
        }
        else
        {
            _price.Hide();
        }
    }
    public void Selected(bool isSelect)
    {
        _selectionImage.gameObject.SetActive(isSelect);
    }
    public void Highlight(bool isHighLight)
    {
        if (isHighLight == true)
        {
            _backgroundImage.sprite = _highlightBackground;
        }
        else
        {
            _backgroundImage.sprite = _standartBackground;
        }
    }

}
