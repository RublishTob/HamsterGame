using System;
using System.Collections.Generic;
using UnityEngine;
/*
 * Summary: 
 * this class is mediator, it response for navigation other panels and menu/button
*/
public class UIRouter
{
    public event Action<string> PanelEnable;
    public event Action<string> MenuEnable;

    private List<string> KeyPanels;
    private List<string> KeyMenus;

    public UIRouter() 
    {
        KeyMenus = new List<string>() { "NewGame","LoadGame","Settings","BackMenu" };
        KeyPanels = new List<string>() { "NewGamePanel", "LoadGamePanel", "SettingsPanel" };
    }


    public void OpenPanel(string key)
    {
        if (IsValid(KeyMenus, key))
        {
            PanelEnable?.Invoke(key);
        }
    }
    public void OpenMenu(string key)
    {
        if (IsValid(KeyPanels, key))
        {
            MenuEnable?.Invoke(key);
        }
    }
    private bool IsValid ( List<string>KeyElements, string key)
    {
        if (KeyElements.Count <= 0) { return false; }

        if (KeyElements.Contains(key) != true) { return false; }

        return true;
    }
}
