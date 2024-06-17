using System;
using System.Collections.Generic;

public class LevelSave
{
    public LevelSave(string name, DateTime date, int level)
    {
        Name = name;
        Date = date;
        Level = level;
    }
    public string Name { get; private set; }
    public DateTime Date { get; private set; }
    public int Level { get; private set; }

    public int DifficultyOfLevel { get; private set; }

    public List<int> EnemyKilledId;
    public PlayerPositionRotation PositionPlayer { get; private set; }
    public int CoinTaked {  get; private set; }

    public void SetLevelData(StateLevelData data)
    {
        DifficultyOfLevel = data.DifficultyOfLevel.Value;
        PositionPlayer = data.PositionPlayer;
        CoinTaked = data.CoinTaked.Value;
    }
}
