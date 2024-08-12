using UnityEngine;

public class MouseVisible : MonoBehaviour
{
    [SerializeField] private Texture2D texture;
    void Start()
    {
        SetCursorLook();
    }
    public void SetCursorLook()
    {
        Cursor.SetCursor(texture, Vector3.zero, CursorMode.Auto);
    }
    public void SetVisible(bool visible)
    {
        if (visible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

}
