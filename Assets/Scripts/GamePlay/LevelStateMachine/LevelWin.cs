
public class LevelWin : LevelState
{
    private MouseVisible _mouse;
    private UIRouter _router;
    private GlobalEventState _globalEvent;
    private MenuLayout _menuLayout;
    private PanelLayout _panelLayout;
    public LevelWin(LevelStateMachine stateMachine, MouseVisible mouse, UIRouter router, GlobalEventState globalEvent, MenuLayout menuLayout, PanelLayout panelLayout) : base(stateMachine)
    {
        _mouse = mouse;
        _router = router;
        _globalEvent = globalEvent;
        _menuLayout = menuLayout;
        _panelLayout = panelLayout;
    }


    public override void Exit()
    {
        _menuLayout.DisposeElements();
        _panelLayout.DisposePanel();
    }

    public override void Start()
    {
        _globalEvent.PauseGame();
        _globalEvent.WinGame();
        _router.OpenWinMenu();
        _mouse.SetVisible(true);
    }

    public override void Update()
    {
    }
}