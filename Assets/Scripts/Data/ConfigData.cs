
using System.Collections.Generic;

public class ConfigData : IConfigData
{
    public List<LevelViewConfig> levels {  get; set; }
    public NewLevelConfig newLevelConfig { get; set; }
    public IEnumerable<LevelViewConfig> Levels => levels;
}
