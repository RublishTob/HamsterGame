
public class LevelLoose : LevelState
{
    private UIRouter _router;
    private GlobalEventState _globalEvent;
    private MenuLayout _menuLayout;
    private PanelLayout _panelLayout;
    private MouseVisible _mouse;
    private SoundResultGame _soundResultGame;
    public LevelLoose(LevelStateMachine stateMachine, UIRouter router, GlobalEventState globalEvent, MenuLayout menuLayout, PanelLayout panelLayout, MouseVisible mouse, SoundResultGame soundResultGame) : base(stateMachine)
    {
        _router = router;
        _globalEvent = globalEvent;
        _menuLayout = menuLayout;
        _panelLayout = panelLayout;
        _mouse = mouse;
        _soundResultGame = soundResultGame;
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
        _soundResultGame.PlayLooseGame();
    }

    public override void Update()
    {
    }
}
