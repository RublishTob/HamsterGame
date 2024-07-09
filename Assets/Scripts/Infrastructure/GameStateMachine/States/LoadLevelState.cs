using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.LookDev;
using UnityEngine.SceneManagement;

public class LoadLevelState : GameState
{
    private UIFactory _uiFactory;
    private LevelLoaderSystem _levelLoader;
    private GameStateMachine _gameStateMachine;
    private SceneLoader _sceneLoader;
    private SaveLoadSystem _saveLoadSystem;
    private PersistentData _data;
    private IDataProvider _povider;
    private UIRouter _router;
    public LoadLevelState(GameStateMachine stateMachine, UIFactory uIFactory, LevelLoaderSystem levelLoader, SceneLoader loader, SaveLoadSystem saveLoadSystem, PersistentData data, IDataProvider povider, UIRouter router) : base(stateMachine)
    {
        _uiFactory = uIFactory;
        _levelLoader = levelLoader;
        _gameStateMachine = stateMachine;
        _sceneLoader = loader;
        _saveLoadSystem = saveLoadSystem;
        _data = data;
        _povider = povider;
        _router = router;
    }
    public override void Start()
    {
        if (_data.StateLevelData == null)
        {
            LevelSave save = null;
            if (_data.levelSaves == null)
            {
                save = new LevelSave($"NewGame({0})", DateTime.Now, SceneManager.sceneCount);
            }
            else
            {
                save = new LevelSave ($"NewGame({_data.levelSaves.Count})",DateTime.Now,SceneManager.sceneCount);
            }
            _saveLoadSystem.Create(save);
        }
        _levelLoader.LoadingScene();
    }
    public override void Update()
    {
        if (_sceneLoader.IsDone)
        {
            _gameStateMachine.SwichState<GameLoopState>();
            _router.HideAll();
        }
    }
    public override void Exit()
    {
    }
}
