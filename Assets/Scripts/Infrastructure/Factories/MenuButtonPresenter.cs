
public class MenuButtonPresenter
{
    private string _id;
    private string _text;

    private ButtonView _view;
    private UIRouter _router;
    private LocalizationManager _localization;
    public MenuButtonPresenter(ButtonView view, UIRouter router, LocalizationManager localization)
    {
        _view = view;
        _router = router;
        _localization = localization;
    }
    public void Show()
    {
        _text = _localization.GetString(_id);
        _view.SetTitle(_text);
        _view.gameObject.SetActive(true);
        _view.OnClick += Click;
    }
    public void Hide()
    {
        _view.gameObject.SetActive(false);
        _view.OnClick -= Click;
    }
    public void Click()
    {

    }
}
