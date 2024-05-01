
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour, MenuButtonView
{
    [SerializeField] public TMP_Text _title;
    [SerializeField] public Button _button;
    public event Action Setting;
    public void SetTitle(string title)
    {
    }

    public void ShowPanel()
    {
        Setting?.Invoke();
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
