
public abstract class ButtonPresenter
{
    private string _text;
    private ButtonView _view;
    private LocalizationSystem _localization;
    public ButtonPresenter(ButtonView view, LocalizationSystem localization, string id)
    {
        Id = id;
        _view = view;
        _localization = localization;
        _localization.TranslateText += Localize;
        Localize();
    }
    public string Id { get; private set; }
    public void Show()
    {
        _view.OnClick += Click;
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
        _view.SetTitle(_text);
    }
    public abstract void Click();
}
