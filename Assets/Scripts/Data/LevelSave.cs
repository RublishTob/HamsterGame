using System;
using System.Collections.Generic;

public class LevelSave
{
    private List<int> CoinToken = new List<int>();
    private List<int> CoinNotToken = new List<int>();

    public IEnumerable<int> CoinTaken => CoinToken;
    public IEnumerable<int> CoinUsed => CoinNotToken;

    public LevelSave(string name, DateTime date, int level)
    {
        Name = name;
        Date = date;
        Level = level;
    }
    public float x { get; set; }
    public float y { get; set; }
    public float z { get; set; }
    public float x_rot { get; set; }
    public float y_rot { get; set; }
    public float z_rot { get; set; }
    public float w_rot { get; set; }

    public float CameraRot_X { get; set; }
    public float CameraRot_Y { get; set; }

    public string Name { get; private set; }
    public DateTime Date { get; private set; }
    public int Level { get; private set; }
    public float Count { get; set; }
    public bool IsTimerRun { get; set; }

    public void SetLevelData(StateLevelData data)
    {
        x = (float)data.x;
        y = (float)data.y;
        z = (float)data.z;
        x_rot = (float)data.x_rot;
        y_rot = (float)data.y_rot;
        z_rot = (float)data.z_rot;
        w_rot = (float)data.w_rot;

        CameraRot_X = (float)data.CameraRot_X;
        CameraRot_Y = (float)data.CameraRot_Y;

        IsTimerRun = data.IsTimerRun;
        Count = data.Count;

        foreach (var item in data.CoinToken)
        {
            CoinToken.Add(item);
        }
        foreach (var item in data.CoinNotToken)
        {
            CoinNotToken.Add(item);
        }
    }
}
