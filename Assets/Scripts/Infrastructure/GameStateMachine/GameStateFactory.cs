
using Zenject;

public class GameStateFactory
{
    private DiContainer _container;
    public GameStateFactory(DiContainer container)
    {
        _container = container;
    }
    public T Create<T>() where T : GameState 
    {
        T gameState = _container.Resolve<T>();

        return gameState;
    }
}
