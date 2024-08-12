using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _button;

    public event Action OnClick;

    private void OnEnable()
    {
        _button.onClick.AddListener(ClickButton);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(ClickButton);
    }
    private void ClickButton()
    {
        OnClick?.Invoke();
    }
    public void SetTitle(string text)
    {
        _text.text = text;
    }
}