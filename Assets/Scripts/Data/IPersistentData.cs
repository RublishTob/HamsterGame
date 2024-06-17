
using System.Collections.Generic;

public interface IPersistentData
{
    public PlayerSave PlayerData { get;}
    public LocalizationData LocalizateData { get;}
    public Settings Settings { get; set; }
    public StateLevelData StateLevelData { get;}
    public IEnumerable<LevelSave> LevelSaves { get; }
}

