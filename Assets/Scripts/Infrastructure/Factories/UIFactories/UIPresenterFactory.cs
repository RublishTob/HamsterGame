
public class UIPresenterFactory
{
    private UIRouter _router;
    private Localization _localization;

    public UIPresenterFactory(UIRouter router, Localization localization)
    {
        _router = router;
        _localization = localization;
    }
    public ButtonPresenter CreateButtonContoller(ButtonView view, TextKey type)
    {
        ButtonPresenter buttonController = new ButtonPresenter(view, _router,_localization,"поменять id"); // поменять id
        return buttonController;
    }

}
