
public class InitializeGame : GameState
{
    private IPersistentData _persistentPlayerData;
    private IDataProvider _dataProvider;
    private Logger _logger;
    private InputPlayer _input;
    private Localization _localization;
    public InitializeGame(GameStateMachine stateMachine, IPersistentData data, DataLocalProvider provider, Logger logger ,InputPlayer input, Localization localization) : base(stateMachine)
    {
        _localization = localization;
        _persistentPlayerData = data;
        _dataProvider = provider;
        _logger = logger;
        _input = input;
    }
    public void LoadDataOrCreate()
    {
        _dataProvider.TryLoadLocalization("Ru");
        //_dataProvider.TryLoadLocalization("Eng");

        _localization.ChangeLanguage("Ru");
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
