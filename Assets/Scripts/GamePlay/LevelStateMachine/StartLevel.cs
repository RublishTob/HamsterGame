
using UnityEngine;
using UnityEngine.InputSystem;

public class StartLevel : LevelState
{
    private UIRouter _router;
    private InputPlayer _playerInput;
    private SoundGamePlay _playSound;
    private LevelStateMachine _stateMachine;
    private MouseVisible _mouse;
    private StateLevelData _stateLevelData;
    private LevelProgressService _progressService;
    private Counter _counter;
    public StartLevel(LevelStateMachine stateMachine, UIRouter router, InputPlayer playerInput, SoundGamePlay playSound, MouseVisible mouse, StateLevelData stateLevelData, Counter counter, LevelProgressService progressService) : base(stateMachine)
    {
        _router = router;
        _playerInput = playerInput;
        _stateMachine = stateMachine;
        _playSound = playSound;
        _mouse = mouse;
        _stateLevelData = stateLevelData;
        _counter = counter;
        _progressService = progressService;
    }
    public override void Start()
    {
        _playerInput.Mover.MenuEnable.started += PauseGame;
        _playSound.PlaySoundAndRepeat(1);
        _router.HideAll();
        if (_stateLevelData.IsTimerRun)
        {
            _counter.StartCount();
            _progressService.Watcher.StartWatchCounter();
        }
        Debug.Log("START LEVEL STATE");
    }

    private void PauseGame(InputAction.CallbackContext context)
    {
        _mouse.SetVisible(true);
        _stateMachine.SwichState<PauseLevel>();
    }

    public override void Update()
    {
        
    }
    public override void Exit()
    {
        _playerInput.Mover.MenuEnable.started -= PauseGame;
    }
}
