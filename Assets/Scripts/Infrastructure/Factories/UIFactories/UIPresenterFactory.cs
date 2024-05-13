
public class UIPresenterFactory
{
    private UIRouter _router;
    private Localization _localization;

    public UIPresenterFactory(UIRouter router, Localization localization)
    {
        _router = router;
        _localization = localization;
    }
    public ButtonPresenter CreateButtonContoller(ButtonView view, string id)
    {
        ButtonPresenter buttonController = new ButtonPresenter(view, _router,_localization, id);

        return buttonController;
    }
    public PanelPresenter CreatePanelContoller(PanelView view, string id)
    {
        PanelPresenter panelController = new PanelPresenter(view, _router, _localization, id);
        return panelController;
    }

}
