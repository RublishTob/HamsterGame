
public class GameLoopState : GameState
{
    private UIFactory _uiFactory;
    private UIRouter _router;
    private DisposeManager _disposeManager;
    private StateLevelData _stateLevelData;
    private NewLevelConfig _levelConfig;
    public GameLoopState(GameStateMachine stateMachine, UIFactory uiFactory, UIRouter router, DisposeManager disposeManager, StateLevelData stateLevelData) : base(stateMachine)
    {
        _uiFactory = uiFactory;
        _router = router;
        _disposeManager = disposeManager;
        _stateLevelData = stateLevelData;
    }
    public override void Start()
    {
    }

    public override void Exit()
    {
        _disposeManager.DisposeResourse();
        _stateLevelData.x = null;
        _stateLevelData.y = null;
        _stateLevelData.z = null;
        _stateLevelData.x_rot = null;
        _stateLevelData.y_rot = null;
        _stateLevelData.z_rot = null;
        _stateLevelData.w_rot = null;
        _stateLevelData.CameraRot_X = null;
        _stateLevelData.CameraRot_Y = null;

        _stateLevelData.CoinNotToken.Clear();
        _stateLevelData.CoinToken.Clear();
    }
    public override void Update()
    {
    }
}
