using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PanelLayout : MonoBehaviour
{
    private UIRouter _router;
    private UIFactory _panelFactory;
    private UIPresenterFactory _presenterFactory;

    private SettingPanelPresenter settingsGamePanelPresenter;
    private LoadPanelPresenter _loadPanelPresenter;
    private SavePanelPresenter _saveGamePanelPresenter;
    private GamePanelPresenter _gamePanelPresenter;

    [SerializeField] private SettingPanelView _settingPanelView;
    [SerializeField] private GamePanelView _gamePanelView;
    [SerializeField] private LoadPanelView _loadPanelView;

    private List<IPanel> _panels;

    [Inject]
    public void Construct(UIRouter router, UIFactory panelFactory, UIPresenterFactory presenterFactory)
    {
        _panels = new List<IPanel>();

        _router = router;
        _panelFactory = panelFactory;
        _presenterFactory = presenterFactory;

        _router.MenuEnable += HideAllPanel;
        _router.PanelEnable += ShowPanel;
        CreatePanels();
        HideAllPanel();
    }

    private void CreatePanels()
    {
        _settingPanelView = Instantiate(_settingPanelView, transform);
        settingsGamePanelPresenter = _presenterFactory.CreateSettingsPanelContoller(_settingPanelView);
        _panels.Add(settingsGamePanelPresenter);

        _loadPanelView = Instantiate(_loadPanelView, transform);
        _loadPanelPresenter = _presenterFactory.CreateLoadPanelContoller(_loadPanelView);
        _panels.Add(_loadPanelPresenter);

        _gamePanelView = Instantiate(_gamePanelView, transform);
        _gamePanelPresenter = _presenterFactory.CreateGamePanelContoller(_gamePanelView);
        _panels.Add(_gamePanelPresenter);
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
            case "Save":
                ShowConcretePanel("SavePanel");
                break;
        }
    }
    private void ShowConcretePanel(string name)
    {
        HideAllPanel();
        gameObject.SetActive(true);
        for (int i =0 ; i < _panels.Count; i++)
        {
            IPanel presenter;
            if (_panels[i].Id == name)
            {
                presenter = _panels[i];
                presenter.Show(name);
                break;
            }
            //_panels[i].Hide();
        }
    }
    private void HideAllPanel()
    {
        for (int i = 0; i < _panels.Count; i++)
        {
            _panels[i].Hide();
        }
        gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        _router.MenuEnable -= HideAllPanel;
        _router.PanelEnable -= ShowPanel;
        //_panels.Clear();
    }
}
