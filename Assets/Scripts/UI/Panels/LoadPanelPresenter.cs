using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class LoadPanelPresenter : IPanel
{
    public event Action LoadLevel;

    [SerializeField] private Button _button;
    [SerializeField] private LoadBarShower _loadBar;
    private PersistentData _data;
    private UIRouter _router;

    private SceneLoader _sceneLoader;
    private SceneUnlocker _unlockerScene;
    private List<LoadLevelButtonPresenter> _levels;
    private LevelSave _save;
    private SaveLoadSystem _repository;
    private LevelLoaderSystem _loaderSystem;
    private GameStateMachine _gameStateMachine;
    private LoadPanelView _view;
    public LoadPanelPresenter(LoadPanelView view, SceneUnlocker unlockerScene, SaveLoadSystem repository, SceneLoader loader, PersistentData data, UIRouter router, LevelLoaderSystem loaderSystem, GameStateMachine gameStateMachine)
    {
        _view = view;
        _router = router;
        _unlockerScene = unlockerScene;
        _sceneLoader = loader;
        _data = data;
        _repository = repository;
        _loaderSystem = loaderSystem;
        _gameStateMachine = gameStateMachine;
        _router.PanelEnable += Show;
        _router.MenuEnable += Hide;
    }
    public string Id { get => "LoadGamePanel"; }
    public string ChoosenLevel { get; private set; }
    private void OnBack()
    {
        _router.OpenMenu("LoadGamePanel");
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
        ShowAllSaves();
    }
    private void ShowAllSaves()
    {
        if (_repository.LevelSaves == null)
        {
            return;
        }
        foreach (var save in _repository.LevelSaves)
        {
            _view.InitSaves(save.Name);
        }
    }
    private void ChoisenLevel(string nameSave)
    {
        ChoosenLevel = nameSave;
    }
    public void SaveLevelState()
    {
        if (_data.StateLevelData == null)
        {
            return;
        }
        _data.StateLevelData.DifficultyOfLevel.Value = _save.DifficultyOfLevel;
        _data.StateLevelData.EnemyKilledId = (ReactiveCollection<int>)_save.EnemyKilledId;
        _data.StateLevelData.CoinTaked.Value = _save.CoinTaked;
        _data.StateLevelData.PositionPlayer = _save.PositionPlayer;
        Hide();
    }
    public void Hide()
    {
        _view.Button.onClick.RemoveListener(Load);
        _view.gameObject.SetActive(false);
    }

    public void Load()
    {
        if (ChoosenLevel == null)
        {
            return;
        }
        var save = _repository.ReadSave(ChoosenLevel);
        _loaderSystem.ChangeCurrentScene(save.Level);
        _repository.LoadLevelData(ChoosenLevel);
        _gameStateMachine.SwichState<LoadLevelState>();
    }
}
