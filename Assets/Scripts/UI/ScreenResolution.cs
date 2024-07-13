using UnityEngine;

public class ScreenResolution : MonoBehaviour
{
    public void SetScreenResolution(int height, int width, bool isFullScreen = true)
    {
        Screen.SetResolution(height, width, isFullScreen);
    }
}
