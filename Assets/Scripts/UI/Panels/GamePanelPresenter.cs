using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanelPresenter : IPanel
{
    public event Action LoadLevel;

    [SerializeField] private Button _button;
    [SerializeField] private LoadBarShower _loadBar;

    private readonly string[] _keyLabels = { "New_Level", "Play" };

    private PersistentData _data;
    private UIRouter _router;
    private IConfigData _config;
    private SoundSystem _soundSystem;
    private SceneLoader _sceneLoader;
    private SceneUnlocker _unlockerScene;
    private LocalizationSystem _localization;
    private List<LevelPresenter> _levels;
    private LevelSave _save;
    private SaveLoadSystem _repository;
    private LevelLoaderSystem _loaderSystem;
    private GameStateMachine _gameStateMachine;
    private List<LevelViewConfig> _viewConfigs;

    private GamePanelView _view;
    public GamePanelPresenter(GamePanelView view, SceneUnlocker unlockerScene, SaveLoadSystem repository, SceneLoader loader, PersistentData data, UIRouter router, IConfigData config, LevelLoaderSystem loaderSystem, GameStateMachine gameStateMachine, LocalizationSystem localization, SoundSystem soundSystem)
    {
        _view = view;
        _router = router;
        _unlockerScene = unlockerScene;
        _sceneLoader = loader;
        _data = data;
        _config = config;
        _localization = localization;

        _localization.TranslateText += Localization;
        _repository = repository;
        Localization();
        _loaderSystem = loaderSystem;
        _gameStateMachine = gameStateMachine;
        _viewConfigs = new List<LevelViewConfig>();
        foreach (var i in _config.Levels)
        {
            _viewConfigs.Add(i);
        }
        _soundSystem = soundSystem;
    }
    public string Id { get => "NewGamePanel"; }
    public int CurrentLevel { get; private set; }
    private void OnBack()
    {
        _soundSystem.Click();
        _router.OpenMenu("LoadGamePanel");
    }
    public void Show(string panel)
    {
        if (panel != "NewGamePanel")
        {
            return;
        }
        _view.ToGame.onClick.AddListener(Load);
        _view.ButtonBack.OnBack += OnBack;
        _view.gameObject.SetActive(true);
        for(int i = 0; i< _viewConfigs.Count; i++)
        {
            _view.Levels[i].SetImage(_viewConfigs[i].levelImage);
            _view.Levels[i].SetName(_viewConfigs[i].level);
            _view.Levels[i].OnLevelClick += Chooselevel;
        }
    }
    public void Hide() 
    {
        _view.ToGame.onClick.RemoveListener(Load);
        _view.ButtonBack.OnBack -= OnBack;
        _view.gameObject.SetActive(false);
    }
    public void Localization()
    {
        for (int i = 0; i < _view.AllTextes.Count; i++)
        {
            _view.AllTextes[i].SetText(_localization.GetString(_keyLabels[i]));
        }
    }
    public void Chooselevel(int level)
    {
        _soundSystem.Click();
        CurrentLevel = level;
        Debug.Log(CurrentLevel);
    }

    public void Load()
    {
        _soundSystem.Click();

        if(CurrentLevel==0)
        {
            return;
        }

        _loaderSystem.ChangeCurrentScene(CurrentLevel);
        _loaderSystem.LoadingScene();
    }
    public void DisposeResourse()
    {
        _localization.TranslateText -= Localization;
    }
}
