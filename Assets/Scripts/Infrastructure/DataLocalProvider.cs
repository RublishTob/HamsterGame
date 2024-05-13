using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataLocalProvider : IDataProvider
{
    private const string SAVE_FILE_EXTENTION = ".json";

    private string fileName;
    private PersistentData _persistentData;

    public DataLocalProvider(PersistentData persistentData)
    {
        _persistentData = persistentData;
    }

    public IPersistentData PersistentData { get => _persistentData; }
    private string SavePath => Application.persistentDataPath;
    private string FullPath => Path.Combine(SavePath, $"{fileName}{SAVE_FILE_EXTENTION}");
    private bool IsDataAlreadyExist() => File.Exists(FullPath);

    public void SaveDataPlayer(PlayerSave data) 
    {
        _persistentData.PlayerData = data;
        Save();
    }
    public void Save()
    {
        File.WriteAllText(FullPath, JsonConvert.SerializeObject(_persistentData.PlayerData, Formatting.Indented, new JsonSerializerSettings
        { 
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        }));
    }
    public bool TryLoadData()
    {
        fileName = "PlayerSave";

        if (IsDataAlreadyExist() == false)
            return false;

        _persistentData.PlayerData = JsonConvert.DeserializeObject<PlayerSave>(File.ReadAllText(FullPath));
        return true;
    }
    public bool TryLoadLocalization(string path) 
    {
        LocalizationData localization = new LocalizationData();

        fileName = path;

        if (IsDataAlreadyExist() == false)
            return false;

        if (path == "Ru")
        {
            localization.Ru = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(FullPath));
        }
        else if (path == "Eng")
        {
            localization.Eng = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(FullPath));
        }

        _persistentData.LocalizateData = localization;
        return true;
    } 
}
