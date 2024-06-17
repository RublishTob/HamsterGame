using System.Collections.Generic;

public class PersistentData : IPersistentData
{
    public PlayerSave PlayerData { get; set; }
    public LocalizationData LocalizateData { get; set; }
    public Settings Settings { get; set; }

    public List<LevelSave> levelSaves { get; set; }
    public IEnumerable<LevelSave> LevelSaves { get => levelSaves; }
    public StateLevelData StateLevelData { get; set; }
}
