
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameButton : MonoBehaviour, MenuButtonView
{
    [SerializeField] public TMP_Text _title;
    [SerializeField] public Button _button;
    public event Action ToGame;
    public void SetTitle(string title)
    {
    }

    public void ShowPanel()
    {
        ToGame?.Invoke();
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
