
public class ButtonPresenter
{
    private string _text;
    private ButtonView _view;
    private UIRouter _router;
    private Localization _localization;
    public ButtonPresenter(ButtonView view, UIRouter router, Localization localization, string id)
    {
        Id = id;
        _view = view;
        _router = router;
        _localization = localization;
        Localize();
    }
    public string Id { get; private set; }
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
        _text = _localization.GetString(Id);
    }
    private void Click()
    {
        _router.OpenPanel(Id);
    }
}
