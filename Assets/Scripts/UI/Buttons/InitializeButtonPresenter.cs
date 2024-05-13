
public class InitializeButtonPresenter
{
    private const string KEY = "Continue";
    private InitializeButtonView _view;
    private GameStateMachine _stateMachine;
    private Localization _loacalization;
    private string _text;

    public InitializeButtonPresenter(InitializeButtonView view, GameStateMachine stateMachine, Localization loacalization)
    {
        _loacalization = loacalization;
        _view = view;
        _stateMachine = stateMachine;
        _text = _loacalization.GetString(KEY);
        _view.SetText(_text);
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
