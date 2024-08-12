using System.Collections.Generic;
using System.Linq;

public class NewLevelConfig
{
    public List<int> _coins = new List<int>();

    public IEnumerable<int> Coins => _coins;

    //Player position
    public float x { get; set; }
    public float y { get; set; }
    public float z { get; set; }
    public float x_rot { get; set; }
    public float y_rot { get; set; }
    public float z_rot { get; set; }
    public float w_rot { get; set; }
    public float Count { get; set; }
    public float CameraRot_X { get; set; }
    public float CameraRot_Y { get; set; }
    public bool IsTimerRun { get; set; }
    public int Level { get; private set; }

}
