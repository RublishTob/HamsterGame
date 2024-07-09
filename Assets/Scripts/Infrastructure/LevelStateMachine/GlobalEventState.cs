using System;
using UnityEngine;

public class GlobalEventState : MonoBehaviour
{
    public event Action IsPaused;
    public event Action IsStarted;
    public void PauseGame()
    {
        IsPaused?.Invoke();
        Debug.Log("PAUSE ALL MTHFCK");
    }
    public void StartGame()
    {
        IsStarted?.Invoke();
        Debug.Log("START ALL MTHFCK");
    }
}
