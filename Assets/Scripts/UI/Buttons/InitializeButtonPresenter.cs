
public class InitializeButtonPresenter
{
    private const string KEY = "Continue";
    private ButtonView _view;
    private GameStateMachine _stateMachine;
    private LocalizationSystem _loacalization;
    private string _text;

    public InitializeButtonPresenter(ButtonView view, GameStateMachine stateMachine, LocalizationSystem loacalization)
    {
        _loacalization = loacalization;
        _view = view;
        _stateMachine = stateMachine;
        _text = _loacalization.GetString(KEY);
        _view.SetTitle(_text);
        Enable();
    }

    public void Enable()
    {
        _view.OnClick += Click;
    }
    public void Desable()
    {
        _view.OnClick -= Click;
    }
    public void Click()
    {
        _stateMachine.SwichState<Menu>();
    }
    public void SetText()
    {
        _view.SetTitle(_text);
    }
}
