
using System;

public class BtnLangPresenter
{
    public event Action<string> OnLangChange;
    private ButtonView _view;
    public string Id { get;}
    public BtnLangPresenter(ButtonView view, string id) 
    { 
        _view = view;
        Id = id;
        _view.OnClick += Click;
    }
    private void Click()
    {
        OnLangChange.Invoke(Id);
    }

}
