
public class LevelLoose : LevelState
{
    private UIRouter _router;
    private GlobalEventState _globalEvent;
    private MenuLayout _menuLayout;
    public LevelLoose(LevelStateMachine stateMachine, UIRouter router, GlobalEventState globalEvent, MenuLayout menuLayout) : base(stateMachine)
    {
        _router = router;
        _globalEvent = globalEvent;
        _menuLayout = menuLayout;
    }

    public override void Exit()
    {
        _menuLayout.UnSubscribe();
    }

    public override void Start()
    {
        _globalEvent.PauseGame();
        _router.OpenLooseMenu();
    }

    public override void Update()
    {
    }
}
