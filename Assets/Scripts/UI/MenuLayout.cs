using System;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using Zenject;

public class MenuLayout : MonoBehaviour
{
    private UIRouter _router;
    private UIFactory _buttonFactory;
    private UIPresenterFactory _presenterFactory;

    private List<ButtonPresenter> _buttons;
    private List<string> KeyPanels;

    [Inject]
    public void Construct(UIRouter router, UIFactory buttonFactory, UIPresenterFactory presenterFactory)
    {
        _buttons = new List<ButtonPresenter>();
        _router = router;
        _buttonFactory = buttonFactory;
        _presenterFactory = presenterFactory;

        CreateButtons();
        _router.MenuEnable += ShowMenu;
        _router.PanelEnable += HideMenu;
        ShowMenu("NewGamePanel");
    }
    private void CreateButtons()
    {
        var newGameButton = _buttonFactory.CreateButton();
        ButtonPresenter newGameButtonPresenter = _presenterFactory.CreateButtonContoller(newGameButton.GetComponent<ButtonView>(), "NewGame");
        newGameButtonPresenter.Show();
        _buttons.Add(newGameButtonPresenter);

        var loadButton = _buttonFactory.CreateButton();
        ButtonPresenter loadButtonPresenter = _presenterFactory.CreateButtonContoller(loadButton.GetComponent<ButtonView>(), "Settings");
        loadButtonPresenter.Show();
        _buttons.Add(loadButtonPresenter);

        var settingsButton = _buttonFactory.CreateButton();
        ButtonPresenter settingsButtonPresenter = _presenterFactory.CreateButtonContoller(settingsButton.GetComponent<ButtonView>(), "LoadGame");
        settingsButtonPresenter.Show();
        _buttons.Add(settingsButtonPresenter);

        var exitGameButton = _buttonFactory.CreateButton();
        ButtonPresenter exitPresenter = _presenterFactory.CreateButtonContoller(exitGameButton.GetComponent<ButtonView>(), "ExitGame");
        exitPresenter.Show();
        _buttons.Add(exitPresenter);
    }

    private void ShowMenu(string panelKey)
    {
        gameObject.SetActive(true);
    }

    private void HideMenu(string obj)
    {
        gameObject.SetActive(false);
    }
}
