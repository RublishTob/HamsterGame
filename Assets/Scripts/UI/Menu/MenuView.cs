using System;
using System.Collections;
using UniRx;
using UnityEngine;
using Zenject;

public class MenuView : MonoBehaviour
{
    public event Action ToGame;
    public event Action LoadGame;
    public event Action SettingsGame;

    [SerializeField] public GameButton _gameButton;
    [SerializeField] private LoadButton _loadButton;
    [SerializeField] private SettingButton _settingButton;

    public void Debbbug()
    {
        Debug.Log($"{ToGame?.GetInvocationList().Length.ToString()}");
        Debug.Log($"{LoadGame?.GetInvocationList().Length.ToString()}");
        Debug.Log($"{SettingsGame?.GetInvocationList().Length.ToString()}");
    }
    private void Start()
    {
        StartCoroutine(dd());
    }
    IEnumerator dd()
    {
        yield return new WaitForSeconds(1f);
        Debbbug();
        EventBus.GameButtonClick();
    }

    public void Construct()
    {
        _gameButton.ToGame += ToGame;
        _loadButton.Load += LoadGame;
        _settingButton.Setting += SettingsGame;
    }

    private void OnDisable()
    {
        _gameButton.ToGame -= ToGame;
        _loadButton.Load -= LoadGame;
        _settingButton.Setting -= SettingsGame;
    }
}
