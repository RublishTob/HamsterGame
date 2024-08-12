
public class ToMainButtonPresenter : ButtonPresenter
{
    private UIRouter _router;
    private GameStateMachine _gameStateMachine;
    private SoundSystem _soundSystem;
    public ToMainButtonPresenter(ButtonView view, LocalizationSystem localization, string id, UIRouter router, GameStateMachine gameStateMachine, SoundSystem soundSystem) : base(view, localization, id)
    {
        _router = router;
        _gameStateMachine = gameStateMachine;
        _soundSystem = soundSystem;
    }

    public override void Click()
    {
        _soundSystem.Click();
        _gameStateMachine.SwichState<Menu>();
        _router.OpenMainMenu();
    }
}
