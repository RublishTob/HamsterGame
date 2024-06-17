using UnityEngine;
internal interface IRotatable
{
    public void Rotate(Quaternion target, float speed);
}