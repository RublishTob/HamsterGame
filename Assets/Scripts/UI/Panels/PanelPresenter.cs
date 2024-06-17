using UnityEngine;

public class PanelPresenter
{
    private string _text;
    private PanelView _view;
    private UIRouter _router;
    private LocalizationSystem _localization;
    public PanelPresenter(PanelView view, UIRouter router, LocalizationSystem localization, string id)
    {
        _view = view;
        Id = id;
        _router = router;
        _localization = localization;
        //Localize();
    }
    public string Id { get; private set; }

    public void Show()
    {
        _view.gameObject.SetActive(true);
        _view.OnClick += Click;
        //_view.SetTitle(_text);
        //_localization.TranslateText += Localize;
    }
    public void Hide()
    {
        _view.OnClick -= Click;
        _view.gameObject.SetActive(false);
        //_localization.TranslateText -= Localize;
    }
    //public void Localize()
    //{
    //    _text = _localization.GetString(_id);
    //}
    private void Click()
    {
        _router.OpenMenu(Id);
    }
}
