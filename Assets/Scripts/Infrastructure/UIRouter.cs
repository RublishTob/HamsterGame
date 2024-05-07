using System;
using System.Collections.Generic;
/*
 * Summary: 
 * this class is mediator, it response for navigation other panels and menu/button
*/
public class UIRouter
{
    public event Action<string> PanelEnable;
    public event Action<string> MenuEnable;

    private List<string> KeyPanels = new();
    private List<string> KeyMenus= new();

    public void OpenPanel(string key)
    {
        if (IsValid(KeyPanels, key))
        {
            MenuEnable?.Invoke(key);
        }
    }
    public void OpenMenu(string key)
    {
        if (IsValid(KeyMenus, key))
        {
            PanelEnable?.Invoke(key);
        }
    }
    private bool IsValid ( List<string>KeyElements, string key)
    {
        if (KeyElements.Count <= 0) { return false; }

        if (KeyElements.Contains(key) != true) { return false; }

        return true;
    }
}
