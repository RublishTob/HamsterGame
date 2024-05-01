using UnityEngine;

public class Gravity : MonoBehaviour
{
    private PlayerViewDetect _sensors;
    private Movable _movable;
    public float GravityForce { get; private set; }

    private void Start()
    {
        _sensors = GetComponent<PlayerViewDetect>();
        _movable = GetComponent<Movable>();
    }
    public void DoGravity(bool gravityExist ,bool isGrounded, float gravityScale)
    {
        if (gravityExist == false)
        {
            return;
        }
        if (isGrounded == false)
        {
            Debug.Log("� �������");
            GravityForce += gravityScale * Time.deltaTime;
        }
        else
        {
            Debug.Log("�� �� �����");
            GravityForce = 0f;
        }
    }
}
