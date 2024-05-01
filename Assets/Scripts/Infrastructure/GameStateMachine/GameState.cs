
public abstract class GameState
{
    private GameStateMachine _stateMachine;
    public GameState(GameStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public abstract void Start();

    public abstract void Update();

    public abstract void Exit();
}
