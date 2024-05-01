using UnityEngine;
internal interface IMovable
{
    public void ChangeHorizontalDirection(Vector3 moveDirection);
    public void Jump();
}