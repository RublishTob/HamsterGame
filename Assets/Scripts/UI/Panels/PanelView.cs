using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _button;

    public event Action OnClick;

    private void OnEnable()
    {
        _button.onClick.AddListener(() => OnClick?.Invoke());
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(() => OnClick?.Invoke());
    }
    public void SetTitle(string text)
    {
        _text.text = text;
    }
}
