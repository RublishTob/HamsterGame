using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using TMPro;

public class SettingPanelView : MonoBehaviour
{
    public event Action OnValueSaved;

    [SerializeField] public List<TextView> AllTextesOnThePanel;
    [SerializeField] public ButtonView[] ButtonsOfLangueges;
    [field:SerializeField] public Slider Volume { get; private set; }
    [field: SerializeField] public Slider MouseSense { get; private set; }
    [field: SerializeField] public TMP_Dropdown Resolution { get; private set; }

    [SerializeField] private Button _backToMenu;

    private void Start()
    {
        _backToMenu.onClick.AddListener(()=> OnValueSaved?.Invoke());
    }
    public void SetVolume(float value) { Volume.value = value;}
    public void SetMouseSense(float value) { MouseSense.value = value;}
    public void SetResolution(int value) { Resolution.value = value;}

    private void OnDisable()
    {
        _backToMenu.onClick.RemoveListener(() => OnValueSaved?.Invoke());
    }
}
