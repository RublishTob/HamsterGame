using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GamePanelPresenter : IPanel
{
    public event Action LoadLevel;

    [SerializeField] private Button _button;
    [SerializeField] private LoadBarShower _loadBar;
    private PersistentData _data;
    private UIRouter _router;
    private IConfigData _config;

    private SceneLoader _sceneLoader;
    private SceneUnlocker _unlockerScene;
    private List<LevelPresenter> _levels;
    private LevelSave _save;
    private SaveLoadSystem _repository;
    private LevelLoaderSystem _loaderSystem;
    private GameStateMachine _gameStateMachine;

    private GamePanelView _view;
    public GamePanelPresenter(GamePanelView view, SceneUnlocker unlockerScene, SaveLoadSystem repository, SceneLoader loader, PersistentData data, UIRouter router, IConfigData config, LevelLoaderSystem loaderSystem, GameStateMachine gameStateMachine)
    {
        _view = view;
        _router = router;
        _unlockerScene = unlockerScene;
        _sceneLoader = loader;
        _data = data;
        _config = config;

        _repository = repository;
        _router.PanelEnable += Show;
        _router.MenuEnable += Hide;
        foreach (var i in _config.Levels)
        {
            _view.InitLevelView(i);
        }
        Debug.Log(_config.Levels.Count());
        _loaderSystem = loaderSystem;
        _gameStateMachine = gameStateMachine;
    }
    public string Id { get => "NewGamePanel"; }
    public int CurrentLevel { get; private set; }
    private void OnBack()
    {
        _router.OpenMenu("LoadGamePanel");
    }
    public void Show(string panel)
    {
        if (panel != "NewGamePanel")
        {
            return;
        }
        _view.ChooseLevel += Chooselevel;
        _view.ToGame.onClick.AddListener(Load);
        _view.ButtonBack.OnBack += OnBack;
        _view.gameObject.SetActive(true);
    }
    public void Hide() 
    {
        _view.ChooseLevel -= Chooselevel;
        _view.ToGame.onClick.RemoveListener(Load);
        _view.ButtonBack.OnBack -= OnBack;
        _view.gameObject.SetActive(false);
    }

    public void Chooselevel(int level)
    {
        CurrentLevel = level;
        Debug.Log(CurrentLevel);
    }

    public void Load()
    {
        _loaderSystem.ChangeCurrentScene(CurrentLevel);
        _gameStateMachine.SwichState<LoadLevelState>();
    }
}
