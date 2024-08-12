using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevelButtonView : MonoBehaviour
{
    [SerializeField] public Button _button;

    public event Action<string> OnSaveClicked;

    public TMP_Text _text;

    public void SetText(string nameSave)
    {
        _text.text = nameSave;
    }
    private void OnEnable()
    {
        _button.onClick.AddListener(Click);
    }
    public void Click()
    {
        OnSaveClicked?.Invoke(_text.text);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(Click);
    }
}
