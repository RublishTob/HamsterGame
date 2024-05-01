
public class InitializeButtonPresenter
{
    private const string KEY = "CONTINIUS_BUTTON";
    private InitializeButtonView _view;
    private GameStateMachine _stateMachine;
    private string _text;

    public InitializeButtonPresenter(InitializeButtonView view, GameStateMachine stateMachine)
    {
        _view = view;
        _stateMachine = stateMachine;
        _text = "rr";
        _view.SetText(KEY);
        Enable();
    }

    public void Enable()
    {
        _view.SetEnable(true);
        _view.Button.onClick.AddListener(Click);
    }
    public void Desable()
    {
        _view.SetEnable(false);
        _view.Button.onClick.RemoveListener(Click);
    }
    public void Click()
    {
        _stateMachine.SwichState<Menu>();
    }
    public void SetText()
    {
        _view.SetText(_text);
    }
}
