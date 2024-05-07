
using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class DataLocalProvider : IDataProvider
{
    private const string CONFIGURATION = "DataConfiguration";
    private const string FILE_NAME = "PlayerSave";
    private const string SAVE_FILE_EXTENTION = ".json";

    private IPersistentData _persistentData;
    private IConfigData _config;

    public DataLocalProvider(IPersistentData persistentData, IConfigData config)
    {
        _persistentData = persistentData;
        _config = config;
    }

    public IPersistentData PersistentData { get => _persistentData; }
    private string SavePath => Application.persistentDataPath;
    private string FullPath => Path.Combine(SavePath, $"{FILE_NAME}{SAVE_FILE_EXTENTION}");
    private bool IsDataAlreadyExist() => File.Exists( FullPath );

    public void SaveDataPlayer(PlayerData data) 
    {
        _persistentData.PlayerData = data;
        Save();
    }

    //public IConfigData LoadConfig<T>() where T : IConfigData
    //{
    //    IConfigData config = 
    //}
    //public IPersistentData LoadData<T>() where T : IPersistentData
    //{
    //    IPersistentData data =
    //}


    public void Save()
    {
        File.WriteAllText(FullPath, JsonConvert.SerializeObject(_persistentData.PlayerData, Formatting.Indented, new JsonSerializerSettings
        { 
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        }));
    }
    public bool TryLoad()
    {
        if (IsDataAlreadyExist() == false)
            return false;

        _persistentData.PlayerData = JsonConvert.DeserializeObject<PlayerData>(File.ReadAllText(FullPath));
        return true;    
    }
}
