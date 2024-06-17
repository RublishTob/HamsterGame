
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] public Button _button;
    public event Action OnBack;

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
