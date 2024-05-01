
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackToMenu : MonoBehaviour, MenuButtonView
{
    [SerializeField] public TMP_Text _title;
    [SerializeField] public Button _button;
    public event Action OnBack;
    public void SetTitle(string title)
    {
    }
    public void ShowPanel()
    {
        OnBack?.Invoke();
    }
    private void OnEnable()
    {
        _button.onClick.AddListener(ShowPanel);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(ShowPanel);
    }
}
