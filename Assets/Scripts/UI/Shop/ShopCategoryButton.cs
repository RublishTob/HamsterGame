using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopCategoryButton : MonoBehaviour
{
    public event Action Click;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;
    [SerializeField] private Color _selectColor;
    [SerializeField] private Color _unSelectColor;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }
    public void SetText(string text)
    {
        _text.text = text;
    }
    public void Select()
    {
        _image.color = _selectColor;
    }
    public void UnSelect()
    {
        _image.color = _unSelectColor;
    }
    private void OnClick() => Click?.Invoke();
}
