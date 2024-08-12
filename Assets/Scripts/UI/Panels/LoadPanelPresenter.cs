using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPanelPresenter : IPanel
{
    private readonly string[] _keyLabels = { "LoadGame", "Load" };

    public event Action LoadLevel;

    [SerializeField] private Button _button;
    [SerializeField] private LoadBarShower _loadBar;
    private PersistentData _data;
    private UIRouter _router;

    private SceneLoader _sceneLoader;
    private SceneUnlocker _unlockerScene;
    private List<LoadLevelButtonPresenter> _levels;
    private LevelSave _save;
    private SaveLoadSystem _saveLoadSystem;
    private LocalizationSystem _localization;
    private SoundSystem _soundSystem;
    private LevelLoaderSystem _loaderSystem;
    private GameStateMachine _gameStateMachine;
    private LoadPanelView _view;
    public LoadPanelPresenter(LoadPanelView view, SceneUnlocker unlockerScene, SaveLoadSystem saveLoadSystem, SceneLoader loader, PersistentData data, UIRouter router, LevelLoaderSystem loaderSystem, GameStateMachine gameStateMachine, SoundSystem soundSystem, LocalizationSystem localization)
    {
        _view = view;
        _router = router;
        _unlockerScene = unlockerScene;
        _sceneLoader = loader;
        _data = data;
        _saveLoadSystem = saveLoadSystem;
        _loaderSystem = loaderSystem;
        _gameStateMachine = gameStateMachine;
        ShowAllSaves();
        _saveLoadSystem.CreateLevel += Update;
        _soundSystem = soundSystem;
        _localization = localization;
        Localization();
        _localization.TranslateText += Localization;
    }
    public string Id { get => "LoadGamePanel"; }
    public string ChoosenSave { get; private set; }
    private void OnBack()
    {
        _soundSystem.Click();
        _router.OpenMenu("LoadGamePanel");
    }
    public void Localization()
    {
        for (int i = 0; i < _view.AllTextes.Count; i++)
        {
            _view.AllTextes[i].SetText(_localization.GetString(_keyLabels[i]));
        }
    }
    public void Show(string panel)
    {
        if (panel != "LoadGamePanel")
        {
            return;
        }
        _view.gameObject.SetActive(true);
        _view.Button.onClick.AddListener(Load);
        _view.Back.OnBack += OnBack;
        _view.OnSaveChoosen += ChoisenLevel;
    }
    private void ShowAllSaves()
    {
        if (_saveLoadSystem.LevelSaves == null)
        {
            return;
        }
        foreach (var save in _saveLoadSystem.LevelSaves)
        {
            _view.InitSaves(save.Name);
        }
    }
    private void Update(LevelSave save)
    {
        _view.InitSaves(save.Name);
    }
    private void ChoisenLevel(string nameSave)
    {
        ChoosenSave = nameSave;
        Debug.Log($"you choose one {ChoosenSave}");
    }
    public void Hide()
    {
        _view.Button.onClick.RemoveListener(Load);
        _view.Back.OnBack -= OnBack;
        _view.OnSaveChoosen -= ChoisenLevel;
        _view.gameObject.SetActive(false);
    }
    public void DisposeResourse()
    {
        _saveLoadSystem.CreateLevel -= Update;
        _localization.TranslateText -= Localization;
    }
    public void Load()
    {
        _soundSystem.Click();
        if (ChoosenSave == null)
        {
            return;
        }
        _loaderSystem.LoadSceneWithSave(ChoosenSave);
    }
}
