using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MenuLayout : MonoBehaviour
{
    [SerializeField] private ButtonView buttonView;
    private UIRouter _router;
    private UIFactory _buttonFactory;
    private UIPresenterFactory _presenterFactory;

    private List<NavigateButtonPresenter> _buttons;
    private List<string> KeyPanels;

    [Inject]
    public void Construct(UIRouter router, UIFactory buttonFactory, UIPresenterFactory presenterFactory)
    {
        _buttons = new List<NavigateButtonPresenter>();
        _router = router;
        _buttonFactory = buttonFactory;
        _presenterFactory = presenterFactory;

        CreateButtons();
        _router.MenuEnable += ShowMenu;
        _router.PanelEnable += HideMenu;
        _router.AllMenuDisable += Hide;
        ShowMenu();
    }
    private void CreateButtons()
    {
        buttonView = Instantiate(buttonView, transform);
        NavigateButtonPresenter newGameButtonPresenter = _presenterFactory.CreateButtonContoller(buttonView, "NewGame");
        newGameButtonPresenter.Show();
        _buttons.Add(newGameButtonPresenter);

        buttonView = Instantiate(buttonView, transform);
        NavigateButtonPresenter loadButtonPresenter = _presenterFactory.CreateButtonContoller(buttonView, "Settings");
        loadButtonPresenter.Show();
        _buttons.Add(loadButtonPresenter);

        buttonView = Instantiate(buttonView, transform);
        NavigateButtonPresenter settingsButtonPresenter = _presenterFactory.CreateButtonContoller(buttonView, "LoadGame");
        settingsButtonPresenter.Show();
        _buttons.Add(settingsButtonPresenter);

        buttonView = Instantiate(buttonView, transform);
        NavigateButtonPresenter exitPresenter = _presenterFactory.CreateButtonContoller(buttonView, "ExitGame");
        exitPresenter.Show();
        _buttons.Add(exitPresenter);
    }
    private void OnDestroy()
    {
        if(_buttons.Count > 0)
        {
            _buttons.Clear();
        }
        _router.MenuEnable -= ShowMenu;
        _router.PanelEnable -= HideMenu;
        _router.AllMenuDisable -= Hide;
    }
    public void UnSubscribe()
    {
        _router.MenuEnable -= ShowMenu;
        _router.PanelEnable -= HideMenu;
        _router.AllMenuDisable -= Hide;
    }
    private void ShowMenu()
    {
        gameObject.SetActive(true);
    }

    private void HideMenu(string obj)
    {
        gameObject.SetActive(false);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
