using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SavePanelView : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private GameObject _prefab;

    public event Action<string> OnSaveWasChoosen;
    [field: SerializeField] public BackToMenu ButtonBack { get; }
    [field: SerializeField] public ButtonView ButtonSave { get; }
    [field: SerializeField] public TMP_InputField NameSave { get; }

    private List<SaveButtonView> _buttons;

    private void Start()
    {
        _buttons = new List<SaveButtonView>();
    }
    public void Hide()
    {
        foreach (var button in _buttons)
        {
            Destroy(button.gameObject);
        }
        _buttons.Clear();
    }
    public void CreateSave(string name)
    { 
        var save = Instantiate(_prefab,_transform).GetComponent<SaveButtonView>();
        save.SetId(name);
        save.Click += OnSaveWasChoosen;
        _buttons.Add(save);
    }
}
