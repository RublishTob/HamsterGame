using UnityEngine;

public class LoadLevelState : GameState
{
    private UIFactory _uiFactory;
    private LevelLoaderSystem _levelLoader;
    private GameStateMachine _gameStateMachine;
    private SceneLoader _sceneLoader;
    private SaveLoadSystem _saveLoadSystem;
    private ConfigData _configData;
    private UIRouter _router;
    private StateLevelData _stateLevelData;
    private MouseVisible _mouse;
    public LoadLevelState(GameStateMachine stateMachine, UIFactory uIFactory, LevelLoaderSystem levelLoader, SceneLoader loader, SaveLoadSystem saveLoadSystem, UIRouter router, ConfigData configData, StateLevelData stateLevelData, MouseVisible mouse) : base(stateMachine)
    {
        _uiFactory = uIFactory;
        _levelLoader = levelLoader;
        _gameStateMachine = stateMachine;
        _sceneLoader = loader;
        _saveLoadSystem = saveLoadSystem;
        _router = router;
        _configData = configData;
        _stateLevelData = stateLevelData;
        _mouse = mouse;
    }
    public override void Start()
    {
        _mouse.SetVisible(false);
        _levelLoader.OnLoadScene += LoadDefaultStateData;
        _levelLoader.OnLoadSceneWithSave += LoadCurrentSaveStateData;
        _uiFactory.CreateRoot(new Vector3(0, 0, 0));
        _uiFactory.CreateLoadBar();
        _saveLoadSystem.LoadAllSaves();
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
        _levelLoader.OnLoadScene -= LoadDefaultStateData;
        _levelLoader.OnLoadSceneWithSave -= LoadCurrentSaveStateData;
    }
    private void LoadDefaultStateData(int scene)
    {
        _stateLevelData.x = _configData.newLevelConfig.x;
        _stateLevelData.y = _configData.newLevelConfig.y;
        _stateLevelData.z = _configData.newLevelConfig.z;
        _stateLevelData.x_rot = _configData.newLevelConfig.x_rot;
        _stateLevelData.y_rot = _configData.newLevelConfig.y_rot;
        _stateLevelData.z_rot = _configData.newLevelConfig.z_rot;
        _stateLevelData.w_rot = _configData.newLevelConfig.w_rot;
        _stateLevelData.Count = _configData.newLevelConfig.Count;
        _stateLevelData.CameraRot_Y = _configData.newLevelConfig.CameraRot_Y;
        _stateLevelData.CameraRot_X = _configData.newLevelConfig.CameraRot_X;
        _stateLevelData.IsTimerRun = _configData.newLevelConfig.IsTimerRun;

        //_stateLevelData.CoinNotToken = (System.Collections.Generic.List<int>)_configData.newLevelConfig.Coins;
        foreach (var i in _configData.newLevelConfig.Coins)
        {
            _stateLevelData.CoinNotToken.Add(i);
        }
    }
    private void LoadCurrentSaveStateData(string nameSave)
    {
        var save = _saveLoadSystem.ReadSave(nameSave);

        if (save == null)
        {
            Debug.Log("We dont find a SAVE what you create");
        }

        _stateLevelData.x = save.x;
        _stateLevelData.y = save.y;
        _stateLevelData.z = save.z;
        _stateLevelData.x_rot = save.x_rot;
        _stateLevelData.y_rot = save.y_rot;
        _stateLevelData.z_rot = save.z_rot;
        _stateLevelData.w_rot = save.w_rot;

        _stateLevelData.CameraRot_Y = save.CameraRot_Y;
        _stateLevelData.CameraRot_X = save.CameraRot_X;

        _stateLevelData.Count = save.Count;
        _stateLevelData.IsTimerRun = save.IsTimerRun;
        _stateLevelData.CoinToken.AddRange(save.CoinTaken);
        _stateLevelData.CoinNotToken.AddRange(save.CoinUsed);
    }
}
