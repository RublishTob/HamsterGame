
using System;

public class LevelPresenter
{
    public event Action<int> OnLevelChange;

    private LevelView _view;
    private LevelSave _save;
    public LevelPresenter(LevelView view, LevelSave save) 
    { 
        _view = view;
        _save = save;
    }
    public void Show()
    {

    }
    private void Click(int message)
    {
        OnLevelChange?.Invoke(message);
    }

}
