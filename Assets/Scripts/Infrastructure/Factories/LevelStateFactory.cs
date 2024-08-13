using Zenject;

public class LevelStateFactory
{
    private DiContainer _container;
    public LevelStateFactory(DiContainer container)
    {
        _container = container;
    }
    public T Create<T>() where T : LevelState
    {
        T gameState = _container.Resolve<T>();

        return gameState;
    }
}
