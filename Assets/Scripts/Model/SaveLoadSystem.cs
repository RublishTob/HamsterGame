
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

public class SaveLoadSystem
{
    private PersistentData _data;
    private DataLocalProvider _provider;

    private List<LevelSave> _levelSaves;
    public IEnumerable<LevelSave> LevelSaves => _levelSaves;
    public ReactiveCommand<LevelSave> CreateLevel { get; private set; }
    public ReactiveCommand ReadLevel { get; private set; }
    public ReactiveCommand ReadAllLevel { get; private set; }
    public ReactiveCommand UpdateLevel { get; private set; }
    public ReactiveCommand DeleteLevel { get; private set; }


    public SaveLoadSystem(PersistentData data, DataLocalProvider provider) 
    { 
        _data = data;
        _provider = provider;
        _levelSaves = new List<LevelSave>();
        CreateLevel = new ReactiveCommand<LevelSave>();
        ReadLevel = new ReactiveCommand();
        ReadAllLevel = new ReactiveCommand();
        UpdateLevel = new ReactiveCommand();
        DeleteLevel = new ReactiveCommand();
    }
    public void Create(LevelSave save)
    {
        _data.levelSaves.Add(save);
        CreateLevel.Execute(save);
        _provider.Save();
    }
    public IEnumerable<LevelSave> ReadAllSaves()
    {
        return _data.LevelSaves;
        //удалить
    }
    public void LoadAllSaves()
    {
        _levelSaves = _data.levelSaves;
    }
    public void LoadLevelData(string name)
    {
        var save = LevelSaves.FirstOrDefault(x => x.Name == name);

        _data.StateLevelData.DifficultyOfLevel.Value = save.DifficultyOfLevel;
        _data.StateLevelData.CoinTaked.Value = save.CoinTaked;
        _data.StateLevelData.EnemyKilledId = (ReactiveCollection<int>)save.EnemyKilledId;
        _data.StateLevelData.PositionPlayer = save.PositionPlayer;
    }
    public LevelSave ReadSave(string name)
    {
        for (int i = 0; i < _data.levelSaves.Count; i++)
        {
            if(_data.levelSaves[i].Name == name)
            return _data.levelSaves[i];
        }
        return null;
    }
    public bool Update(string name, LevelSave save)
    {
        for (int i = 0; i < _data.levelSaves.Count; i++)
        {
            if (_data.levelSaves[i].Name == name)
                _data.levelSaves[i] = save;
                return true;
        }
        return false;
    }
    public bool Delete(string name)
    {
        for (int i = 0; i < _data.levelSaves.Count; i++)
        {
            if (_data.levelSaves[i].Name == name)
                _data.levelSaves[i] = null;
            return true;
        }
        return false;
    }
}
