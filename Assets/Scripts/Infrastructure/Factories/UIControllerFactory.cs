
using Zenject;

public class UIControllerFactory
{
    private DiContainer _container;
    private UIRouter _router;
    private LocalizationManager _localization;

    public UIControllerFactory(DiContainer container, UIRouter router, LocalizationManager localization)
    {
        _container = container;
        _router = router;
        _localization = localization;
    }
    public MenuButtonPresenter CreateButtonContoller(ButtonView view, TextKey type)
    {
        MenuButtonPresenter buttonController = new MenuButtonPresenter(view, _router,_localization);
        return buttonController;
    }

}
