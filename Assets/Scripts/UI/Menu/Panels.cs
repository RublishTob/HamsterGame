using System;
using UnityEngine;
using Zenject;

public class Panels : MonoBehaviour
{
    [SerializeField] private SettingPanelView _settingPanel;
    [SerializeField] private LoadGamePanelView _loadPanel;
    [SerializeField] private GamePanelView _gamePanel;
    private MenuView _menuView;
    public void ShowPanel(string name)
    {
        OpenPanel(name);
    }

    public void Construct(MenuView menu)
    {
        _menuView = menu;
        //_menuView.ToGame += () => OpenPanel("Game");
        //_menuView.LoadGame += () => OpenPanel("Load");
        //_menuView.SettingsGame += () => OpenPanel("Settings");

    }
    private void OpenPanel(string name)
    {
        switch (name)
        {
            case "Settings":
                _settingPanel.gameObject.SetActive(true);
                _loadPanel.gameObject.SetActive(false);
                _gamePanel.gameObject.SetActive(false);
                break;
            case "Game":
                _settingPanel.gameObject.SetActive(false);
                _loadPanel.gameObject.SetActive(false);
                _gamePanel.gameObject.SetActive(true);
                break;
            case "Load":
                _settingPanel.gameObject.SetActive(false);
                _loadPanel.gameObject.SetActive(true);
                _gamePanel.gameObject.SetActive(false);
                break;
        }
    }
}
