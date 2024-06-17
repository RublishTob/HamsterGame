using UnityEngine;

public class ScreenLook : MonoBehaviour
{
    public void SetScreenResolution(int height, int width, bool isFullScreen = true)
    {
        Screen.SetResolution(height, width, isFullScreen);
    }
}
