using System;
using UnityEngine;

public class GlobalEventState : MonoBehaviour
{
    public event Action IsPaused;
    public event Action IsStarted;
    public event Action IsWin;
    public event Action IsLoose;
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
    public void WinGame()
    {
        IsWin?.Invoke();
        Debug.Log("WIN MTHFCK");
    }
    public void LooseGame()
    {
        IsLoose?.Invoke();
        Debug.Log("LOOSE WTF");
    }
}
