
using System;

public class LoadLevelButtonPresenter
{
    public event Action<string> OnClick;

    private LevelSave _data;
    private LoadLevelButtonView _view;

    public LoadLevelButtonPresenter(LoadLevelButtonView view, LevelSave data) 
    {
        _view = view;
        _data = data;
    }
    public void Show()
    {
        _view._button.onClick.AddListener(Click);
        _view.SetText($"{_data.Name} {_data.Date}");
    }
    public void Hide()
    {
        _view._button.onClick.RemoveListener(Click);
    }
    private void Click()
    {
        OnClick?.Invoke(_data.Name);
    }
}
