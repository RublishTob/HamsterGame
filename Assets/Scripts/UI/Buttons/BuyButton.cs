using DG.Tweening;
using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public event Action Click;

    public Button _button;
    [SerializeField] private TMP_Text _text;

    [SerializeField] private Color _lockColor;
    [SerializeField] private Color _unlockColor;

    [SerializeField, Range(0, 1)] private float _lockAnimationDuration = 0.4f;
    [SerializeField, Range(0.5f, 5)] private float _lockAnimationStreigth = 2f;

    private bool _isLock;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }
    public void UpdatePrice(string price)
    {
        _text.text = price;
    }
    public void Lock()
    {
        _isLock = true;
        _text.color = _lockColor;
    }
    public void Unlock()
    {
        _isLock = false;
        _text.color = _unlockColor;
    }
    private void OnButtonClick()
    {
        if(_isLock)
        {
            transform.DOShakePosition(_lockAnimationDuration, _lockAnimationStreigth);
            return;
        }
        Click?.Invoke();
    }
}
