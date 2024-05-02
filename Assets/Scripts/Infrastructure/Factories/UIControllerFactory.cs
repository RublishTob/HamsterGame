
using Zenject;

public class UIControllerFactory
{
    private DiContainer _container;
    private ButtonView _view;
    private UIRouter _router;
    private LocalizationManager _localization;

    public UIControllerFactory(DiContainer container, UIRouter router, LocalizationManager localization)
    {
        _container = container;
        _router = router;
        _localization = localization;
    }
    public ButtonController CreateButtonContoller(ButtonView view, ButtonType type)
    {
        _view = view;
        ButtonController buttonController = GetController(type);
        _container.Inject(buttonController);
        return buttonController;
    }
    private ButtonController GetController(ButtonType type)
    {
        ButtonController controller = null;
        switch (type)
        {
            case ButtonType.Exit:
                controller = new ExitButtonCtrl(_view,_router,_localization);
                break;
            case ButtonType.Load:
                controller = new LoadButtonCtrl(_view, _router, _localization);
                break;
            case ButtonType.Games:
                controller = new PlayGameButtonCtrl(_view, _router, _localization);
                break;
            case ButtonType.Settings:
                controller = new SettingsButtonController(_view, _router, _localization);
                break;
        }
        return controller;

    }

}
