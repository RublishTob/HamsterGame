using UnityEngine;

public class PlayerPositionRotation
{
    private float x { get; }
    private float y { get; }
    private float z { get; }
    private float x_rot { get; }
    private float y_rot { get; }
    private float z_rot { get; }
    private float w_rot { get; }

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
