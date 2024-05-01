
public class InitializeGame : GameState
{
    private IPersistentData _persistentPlayerData;
    private IDataProvider _dataProvider;
    private Logger _logger;
    private InputPlayer _input;
    public InitializeGame(GameStateMachine stateMachine, IPersistentData data, DataLocalProvider provider,Logger logger ,InputPlayer input) : base(stateMachine)
    {
        _persistentPlayerData = data;
        _dataProvider = provider;
        _logger = logger;
        _input = input;
    }
    public void LoadDataOrCreate()
    {
        if (_dataProvider.TryLoad() == false)
        {
            _persistentPlayerData.PlayerData = new PlayerData();
            _logger.Log("Can't find a Player_data, create new");
        }
    }
    public override void Start()
    {
        LoadDataOrCreate();
        _input.Enable();
    }
    public override void Update()
    {
    }
    public override void Exit()
    {
    }


}
