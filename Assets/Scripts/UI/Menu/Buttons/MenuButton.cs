using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] public TMP_Text _title;
    [SerializeField] public Button _button;
    public event Action Click;

    public void SetTitle(string title)
    {
        _title.text = title;
    }

    public void ShowPanel()
    {
        Click?.Invoke();
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
