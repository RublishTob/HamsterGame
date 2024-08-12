using UnityEngine;

public class PlayerPositionRotation
{
    private float x { get; set; }
    private float y { get; set; }
    private float z { get; set; }
    private float x_rot { get; set; }
    private float y_rot { get; set; }
    private float z_rot { get; set; }
    private float w_rot { get; set; }

    public PlayerPositionRotation(Vector3 position, Quaternion rotation)
    {
        x = position.x;
        y = position.y;
        z = position.z;

        x_rot = rotation.x;
        y_rot = rotation.y;
        z_rot = rotation.z;
        w_rot = rotation.w;
    }
}
