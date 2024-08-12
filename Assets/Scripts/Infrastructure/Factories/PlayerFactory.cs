using UnityEngine;
using Zenject;

public class PlayerFactory : MonoBehaviour
{
    private DiContainer _container;

    [Inject]
    public void Construct(DiContainer container)
    {
        _container = container;
    }
    public GameObject Create()
    {
        var playerLoad = _container.Instantiate<PlayerViewDetect>();
        return playerLoad.gameObject;
    }
}
