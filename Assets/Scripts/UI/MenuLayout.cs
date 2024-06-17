using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MenuLayout : MonoBehaviour
{
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
        ShowMenu();
    }
    private void CreateButtons()
    {
        var newGameButton = _buttonFactory.CreateButton();
        NavigateButtonPresenter newGameButtonPresenter = _presenterFactory.CreateButtonContoller(newGameButton.GetComponent<ButtonView>(), "NewGame");
        newGameButtonPresenter.Show();
        _buttons.Add(newGameButtonPresenter);

        var loadButton = _buttonFactory.CreateButton();
        NavigateButtonPresenter loadButtonPresenter = _presenterFactory.CreateButtonContoller(loadButton.GetComponent<ButtonView>(), "Settings");
        loadButtonPresenter.Show();
        _buttons.Add(loadButtonPresenter);

        var settingsButton = _buttonFactory.CreateButton();
        NavigateButtonPresenter settingsButtonPresenter = _presenterFactory.CreateButtonContoller(settingsButton.GetComponent<ButtonView>(), "LoadGame");
        settingsButtonPresenter.Show();
        _buttons.Add(settingsButtonPresenter);

        var exitGameButton = _buttonFactory.CreateButton();
        NavigateButtonPresenter exitPresenter = _presenterFactory.CreateButtonContoller(exitGameButton.GetComponent<ButtonView>(), "ExitGame");
        exitPresenter.Show();
        _buttons.Add(exitPresenter);
    }

    private void ShowMenu()
    {
        gameObject.SetActive(true);
    }

    private void HideMenu(string obj)
    {
        gameObject.SetActive(false);
    }
}
