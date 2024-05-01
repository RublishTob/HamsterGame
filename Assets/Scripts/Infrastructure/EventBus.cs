using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public static event Action OnEvent;

    public static void GameButtonClick()
    {
        OnEvent?.Invoke();
    }
}
