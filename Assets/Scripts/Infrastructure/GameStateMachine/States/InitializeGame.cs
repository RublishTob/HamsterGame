using System;
using UnityEngine;
public class InitializeGame : GameState
{
    private IDataProvider _dataProvider;
    private IPersistentData _data;
    private InputPlayer _input;
    private LocalizationSystem _localization;
    private VideoSystem _videoSystem;
    private ConfigData _conf;
    private MouseVisible _mouse;
    private SaveLoadSystem _saveLoadSystem;
    public InitializeGame(GameStateMachine stateMachine, DataLocalProvider provider,InputPlayer input, LocalizationSystem localization, IPersistentData data, VideoSystem videoSystem, ConfigData conf, SaveLoadSystem saveLoadSystem, MouseVisible mouse) : base(stateMachine)
    {
        _localization = localization;
        _dataProvider = provider;
        _input = input;
        _data = data;
        _videoSystem = videoSystem;
        _conf = conf;
        _saveLoadSystem = saveLoadSystem;
        _mouse = mouse;
    }
    public void LoadDataOrCreate()
    {
        if (_dataProvider.TryLoadData() == false)
        {
            new NotImplementedException("Can't load data");
        }
        if (_dataProvider.TryLoadSavesData() == false)
        {
            Debug.Log("CANT LOAD LEVELDATA...");
        }
        _saveLoadSystem.LoadAllSaves();
        if (_dataProvider.TryLoadLocalization() == false)
        {
            new NotImplementedException("Can't load localization");
        }
        if (_data.Settings.Language == null)
        {
            _localization.ChangeLanguage("Ru");
        }
        else
        {
            _localization.ChangeLanguage(_data.Settings.Language);
        }
        _videoSystem.ChangeResolution(_data.Settings.Resolution);
        if (_dataProvider.TryLoadConfig() == false)
        {
            new NotImplementedException("Can't load configuration");
        }
    }
    public override void Start()
    {
        _mouse.SetVisible(true);
        LoadDataOrCreate();
        _input.Enable();
    }
    public override void Update()
    {
    }
    public override void Exit()
    {
    }


}
