using System.Threading.Tasks;


public class TutorialLevel : LevelState
{
    private Counter _counter;
    private TutorialText _tutorialText;
    private LevelStateMachine _stateMachine;
    private LevelProgressService _progressService;
    public TutorialLevel(LevelStateMachine stateMachine, Counter counter, TutorialText tutorialText, LevelProgressService progressWatcher) : base(stateMachine)
    {
        _stateMachine = stateMachine;
        _counter = counter;
        _tutorialText = tutorialText;
        _progressService = progressWatcher;
    }

    public override void Exit()
    {
        _tutorialText.Hide();
        _progressService.Watcher.StartWatchCounter();
        _counter.StartTimer();
        _counter.StartCount();
    }

    public async override void Start()
    {
        _tutorialText.Print();
        await Task.Delay(4000);
        _stateMachine.SwichState<StartLevel>();
    }

    public override void Update()
    {
    }

}
