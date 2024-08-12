
public abstract class LevelState
{
    private LevelStateMachine _stateMachine;
    public LevelState(LevelStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public abstract void Start();
    public abstract void Update();
    public abstract void Exit();
}
