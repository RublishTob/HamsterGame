using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPanelView : MonoBehaviour
{
    public event Action<string> OnSaveChoosen;
    [SerializeField] public BackToMenu Back;
    [SerializeField] public Button Button;
    [SerializeField] public Transform TransformPanel;
    [SerializeField] public GameObject Prefab;

    private List<GameObject> Saves = new();

    public void InitSaves(string levelname)
    {
        var save = Instantiate(Prefab,TransformPanel);
        save.GetComponent<LoadLevelButtonView>().SetText(levelname);
        save.GetComponent<LoadLevelButtonView>().OnSaveClicked += OnSaveClick;
        Saves.Add(save);
    }
    private void OnSaveClick(string name)
    {
        OnSaveChoosen?.Invoke(name);
    }
}
