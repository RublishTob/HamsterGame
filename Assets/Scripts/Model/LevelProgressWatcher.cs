
public class LevelProgressWatcher
{
    private GameStateMachine _gameStateMachine;
    public LevelProgressWatcher(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
        _gameStateMachine.SwichState<GameLoopState>();
    }
}
