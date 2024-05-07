
public class ButtonPresenter
{
    private string _id;
    private string _text;

    private ButtonView _view;
    private UIRouter _router;
    private Localization _localization;
    public ButtonPresenter(ButtonView view, UIRouter router, Localization localization, string id)
    {
        _id = id;
        _view = view;
        _router = router;
        _localization = localization;
        Localize();
    }
    public void Show()
    {
        _view.SetTitle(_text);
        _view.OnClick += Click;
        _localization.TranslateText += Localize;
        _view.gameObject.SetActive(true);
    }
    public void Hide()
    {
        _view.OnClick -= Click;
        _view.gameObject.SetActive(false);
        _localization.TranslateText -= Localize;
    }
    public void Localize()
    {
        _text = _localization.GetString(_id);
    }
    private void Click()
    {
        _router.OpenPanel(_id);
    }
}
