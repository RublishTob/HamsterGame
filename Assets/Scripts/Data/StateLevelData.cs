using System.Collections.Generic;

public class StateLevelData
{
    public List<int> CoinToken = new List<int>();
    public List<int> CoinNotToken = new List<int>();

    public float? CameraRot_X {  get; set; }
    public float? CameraRot_Y { get; set; }
    public bool IsTimerRun { get; set; }
    public float Count { get; set; }
    public float? x { get; set; }
    public float? y { get; set; }
    public float? z { get; set; }
    public float? x_rot { get; set; }
    public float? y_rot { get; set; }
    public float? z_rot { get; set; }
    public float? w_rot { get; set; }
}
