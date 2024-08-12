using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SavePanelView : MonoBehaviour
{
    public event Action<string> OnSaveWasChoosen;

    [SerializeField] private Transform _transform;
    [SerializeField] private GameObject _prefab;

    [SerializeField] public BackToMenu ButtonBack;
    [SerializeField] public ButtonView ButtonSave;
    [SerializeField] public TMP_InputField NameSave;

    public List<GameObject> _buttons;
    public List<TextView> AllTextes;
    private void OnDestroy()
    {
        foreach (var button in _buttons)
        {
            Destroy(button.gameObject);
        }
        _buttons.Clear();
    }
    public void CreateSave(string name)
    { 
        var save = Instantiate(_prefab,_transform);
        save.GetComponent<SaveButtonView>().SetId(name);
        _buttons.Add(save);
    }
}
