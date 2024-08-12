
public class LevelLoose : LevelState
{
    private UIRouter _router;
    private GlobalEventState _globalEvent;
    private MenuLayout _menuLayout;
    private PanelLayout _panelLayout;
    private MouseVisible _mouse;
    public LevelLoose(LevelStateMachine stateMachine, UIRouter router, GlobalEventState globalEvent, MenuLayout menuLayout, PanelLayout panelLayout, MouseVisible mouse) : base(stateMachine)
    {
        _router = router;
        _globalEvent = globalEvent;
        _menuLayout = menuLayout;
        _panelLayout = panelLayout;
        _mouse = mouse;
    }

    public override void Exit()
    {
        _menuLayout.DisposeElements();
        _panelLayout.DisposePanel();
    }

    public override void Start()
    {
        _globalEvent.PauseGame();
        _globalEvent.LooseGame();
        _router.OpenLooseMenu();
        _mouse.SetVisible(true);
    }

    public override void Update()
    {
    }
}
