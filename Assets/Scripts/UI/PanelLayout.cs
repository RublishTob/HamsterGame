using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PanelLayout : MonoBehaviour
{
    private UIRouter _router;
    private UIFactory _panelFactory;
    private UIPresenterFactory _presenterFactory;

    private List<PanelPresenter> _panels;
    private List<string> KeyMenus;

    [Inject]
    public void Construct(UIRouter router, UIFactory panelFactory, UIPresenterFactory presenterFactory)
    {
        KeyMenus = new List<string>() { "NewGamePanel", "LoadGamePanel", "SettingsPanel" };
        _panels = new List<PanelPresenter>();
        _router = router;
        _panelFactory = panelFactory;
        _presenterFactory = presenterFactory;
        CreatePanels();
        HidePanel("NewGamePanel");
        _router.MenuEnable += HidePanel;
        _router.PanelEnable += ShowPanel;
    }

    private void CreatePanels()
    {
        var newGamePanel = _panelFactory.CreatePanel(TypePanel.NewGame);
        PanelPresenter newGamePanelPresenter = _presenterFactory.CreatePanelContoller(newGamePanel.GetComponent<PanelView>(), "NewGamePanel");
        newGamePanelPresenter.Show();
        _panels.Add(newGamePanelPresenter);

        var loadGamePanel = _panelFactory.CreatePanel(TypePanel.LoadGame);
        PanelPresenter loadGamePanelPresenter = _presenterFactory.CreatePanelContoller(loadGamePanel.GetComponent<PanelView>(), "LoadGamePanel");
        loadGamePanelPresenter.Show();
        _panels.Add(loadGamePanelPresenter);

        var settingsGamePanel = _panelFactory .CreatePanel(TypePanel.Settings);
        PanelPresenter settingsGamePanelPresenter = _presenterFactory.CreatePanelContoller(settingsGamePanel.GetComponent<PanelView>(), "SettingsPanel");
        settingsGamePanelPresenter.Show();
        _panels.Add(settingsGamePanelPresenter);
    }
    private void ShowPanel(string buttonKey)
    {
        gameObject.SetActive(true);

        switch (buttonKey)
        {
            case "NewGame":
                ShowConcretePanel("NewGamePanel");
                break;
            case "LoadGame":
                ShowConcretePanel("LoadGamePanel");
                break;
            case "Settings":
                ShowConcretePanel("SettingsPanel");
                break;
        }
    }
    private void ShowConcretePanel(string name)
    {
        for(int i =0 ; i < _panels.Count; i++)
        {
            PanelPresenter presenter;
            if (_panels[i].Id == name)
            {
                presenter = _panels[i];
                presenter.Show();
                break;
            }
        }
    }
    private void HidePanel(string name)
    {
        if (IsValid(KeyMenus, name) != true)
            return;

        for (int i = 0; i < _panels.Count; i++)
        {
            _panels[i].Hide();
        }
        gameObject.SetActive(false);
    }

    private bool IsValid(List<string> KeyElements, string key)
    {
        if (key == null) return false;

        if (KeyElements.Count <= 0) return false; 

        if (KeyElements.Contains(key) != true) return false; 

        return true;
    }
}
