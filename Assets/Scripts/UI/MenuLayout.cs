using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MenuLayout : MonoBehaviour
{
    [SerializeField] private ButtonView buttonView;
    private UIRouter _router;
    private UIFactory _buttonFactory;
    private DisposeManager _disposeManager;
    private GameStateMachine _gameStateMachine;
    private UIPresenterFactory _presenterFactory;

    private List<ButtonPresenter> _buttons;
    private List<string> KeyPanels;

    [Inject]
    public void Construct(UIRouter router, UIFactory buttonFactory, UIPresenterFactory presenterFactory, GameStateMachine gameStateMachine, DisposeManager disposeManager)
    {
        _buttons = new List<ButtonPresenter>();
        _router = router;
        _buttonFactory = buttonFactory;
        _disposeManager = disposeManager;
        _presenterFactory = presenterFactory;
        _gameStateMachine = gameStateMachine;

        CreateALLButtons();
        _router.MenuEnable += ShowMenu;
        _router.PanelEnable += HideMenu;
        _router.AllMenuDisable += Hide;
        _disposeManager.DisposeRes += DisposeElements;
        ShowMenu();
    }
    private void CreateALLButtons()
    {
        if (_gameStateMachine.CurrentState is Menu)
        {
            CreateMenuButtons();
        }
        if (_gameStateMachine.CurrentState is GameLoopState)
        {
            CreateGameButtons();
        }
    }
    private void CreateMenuButtons()
    {
        buttonView = Instantiate(buttonView, transform);
        ButtonPresenter newGameButtonPresenter = _presenterFactory.CreateButtonContoller(buttonView, "NewGame");
        newGameButtonPresenter.Show();
        _buttons.Add(newGameButtonPresenter);

        buttonView = Instantiate(buttonView, transform);
        ButtonPresenter loadButtonPresenter = _presenterFactory.CreateButtonContoller(buttonView, "Settings");
        loadButtonPresenter.Show();
        _buttons.Add(loadButtonPresenter);

        buttonView = Instantiate(buttonView, transform);
        ButtonPresenter settingsButtonPresenter = _presenterFactory.CreateButtonContoller(buttonView, "LoadGame");
        settingsButtonPresenter.Show();
        _buttons.Add(settingsButtonPresenter);

        buttonView = Instantiate(buttonView, transform);
        ButtonPresenter shopPresenter = _presenterFactory.CreateButtonContoller(buttonView, "Shop");
        shopPresenter.Show();
        _buttons.Add(shopPresenter);

        buttonView = Instantiate(buttonView, transform);
        ButtonPresenter exitPresenter = _presenterFactory.CreateButtonContoller(buttonView, "Exit");
        exitPresenter.Show();
        _buttons.Add(exitPresenter);
    }
    private void CreateGameButtons()
    {
        buttonView = Instantiate(buttonView, transform);
        ButtonPresenter loadButtonPresenter = _presenterFactory.CreateButtonContoller(buttonView, "Settings");
        loadButtonPresenter.Show();
        _buttons.Add(loadButtonPresenter);

        buttonView = Instantiate(buttonView, transform);
        ButtonPresenter newGameButtonPresenter = _presenterFactory.CreateButtonContoller(buttonView, "SaveGame");
        newGameButtonPresenter.Show();
        _buttons.Add(newGameButtonPresenter);

        buttonView = Instantiate(buttonView, transform);
        ButtonPresenter settingsButtonPresenter = _presenterFactory.CreateButtonContoller(buttonView, "LoadGame");
        settingsButtonPresenter.Show();
        _buttons.Add(settingsButtonPresenter);

        buttonView = Instantiate(buttonView, transform);
        ButtonPresenter exitPresenter = _presenterFactory.CreateButtonContoller(buttonView, "ToMenu");
        exitPresenter.Show();
        _buttons.Add(exitPresenter);
    }
    private void OnDestroy()
    {
        _router.MenuEnable -= ShowMenu;
        _router.PanelEnable -= HideMenu;
        _router.AllMenuDisable -= Hide;
        if (_buttons.Count > 0)
        {
            _buttons.Clear();
        }
    }
    public void DisposeElements()
    {
        _router.MenuEnable -= ShowMenu;
        _router.PanelEnable -= HideMenu;
        _router.AllMenuDisable -= Hide;
        _disposeManager.DisposeRes -= DisposeElements;
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
