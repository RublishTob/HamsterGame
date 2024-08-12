using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

public class SaveLoadSystem
{
    private PersistentData _data;
    private SceneLoader _loaderScene;
    private StateLevelData _stateLevelData;
    private DataLocalProvider _provider;
    private List<LevelSave> _levelSaves;
    private List<ISavable> _savable;
    public SaveLoadSystem(PersistentData data, DataLocalProvider provider, StateLevelData stateLevelData, List<ISavable> savable, SceneLoader loaderScene) 
    { 
        _data = data;
        _provider = provider;
        _stateLevelData = stateLevelData;
        _savable = savable;
        _loaderScene = loaderScene;
        _levelSaves = new List<LevelSave>();
        ReadLevel = new ReactiveCommand();
        ReadAllLevel = new ReactiveCommand();
        UpdateLevel = new ReactiveCommand();
        DeleteLevel = new ReactiveCommand();
    }
    public IEnumerable<LevelSave> LevelSaves => _levelSaves;
    public event Action<LevelSave> CreateLevel;
    public event Action SaveData;
    public ReactiveCommand ReadLevel;
    public ReactiveCommand ReadAllLevel;
    public ReactiveCommand UpdateLevel;
    public ReactiveCommand DeleteLevel;

    public void Create(string name, DateTime date, int level)
    {
        SaveData?.Invoke();
        var save = new LevelSave(name, date, level);
        var stateData = new StateLevelData();

        stateData.CameraRot_X = _stateLevelData.CameraRot_X;
        stateData.CameraRot_Y = _stateLevelData.CameraRot_Y;
        stateData.x = _stateLevelData.x;
        stateData.y = _stateLevelData.y;
        stateData.z = _stateLevelData.z;
        stateData.x_rot = _stateLevelData.x_rot;
        stateData.y_rot = _stateLevelData.y_rot;
        stateData.z_rot = _stateLevelData.z_rot;
        stateData.w_rot = _stateLevelData.w_rot;

        stateData.CoinNotToken.AddRange(_stateLevelData.CoinNotToken);
        stateData.CoinToken.AddRange(_stateLevelData.CoinToken);
        stateData.IsTimerRun = _stateLevelData.IsTimerRun;
        stateData.Count = _stateLevelData.Count;

        save.SetLevelData(stateData);
        _data.levelSaves.Add(save);
        CreateLevel?.Invoke(save);
        _provider.Save();
    }
    public IEnumerable<LevelSave> ReadAllSaves()
    {
        return _data.LevelSaves;
    }
    public void LoadAllSaves()
    {
        _levelSaves = _data.levelSaves;
    }
    public LevelSave ReadSave(string name)
    {
        var save = LevelSaves.FirstOrDefault(x => x.Name == name);
        return save;
    }
    //public bool Update(string name, LevelSave save)
    //{
    //    for (int i = 0; i < _data.levelSaves.Count; i++)
    //    {
    //        if (_data.levelSaves[i].Name == name)
    //            _data.levelSaves[i] = save;
    //            return true;
    //    }
    //    return false;
    //}
    //public bool Delete(string name)
    //{
    //    for (int i = 0; i < _data.levelSaves.Count; i++)
    //    {
    //        if (_data.levelSaves[i].Name == name)
    //            _data.levelSaves[i] = null;
    //        return true;
    //    }
    //    return false;
    //}
}
