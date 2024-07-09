using System;
using System.Collections.Generic;

public class UIRouter
{
    public event Action<string> PanelEnable;
    public event Action MenuEnable;
    public event Action AllMenuDisable;
    public event Action LooseMenu;
    public event Action WinMenu;

    private List<string> KeyPanels;
    private List<string> KeyMenus;

    public UIRouter() 
    {
        KeyMenus = new List<string>() { "NewGame","LoadGame","Settings","BackMenu", "SaveLevel" };
        KeyPanels = new List<string>() { "NewGamePanel", "LoadGamePanel", "SettingsPanel", "SavePanel" };
    }
    public void HideAll()
    {
        AllMenuDisable?.Invoke();
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
            MenuEnable?.Invoke();
        }
    }
    public void OpenLooseMenu()
    {
        LooseMenu?.Invoke();
    }
    public void OpenWinMenu()
    {
         WinMenu?.Invoke();
    }
    private bool IsValid ( List<string>KeyElements, string key)
    {
        if (KeyElements.Count <= 0) { return false; }

        if (KeyElements.Contains(key) != true) { return false; }

        return true;
    }
}
