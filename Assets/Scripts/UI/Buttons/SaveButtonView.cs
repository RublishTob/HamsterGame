using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveButtonView : MonoBehaviour
{
    public event Action <string> Click;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(SaveWasChoosen);
    }
    public void SetId(string name)
    {
        _text.text = name;
    }
    private void SaveWasChoosen()
    {
        Click.Invoke(_text.text);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(SaveWasChoosen);
    }
}
