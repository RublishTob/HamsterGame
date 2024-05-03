using UnityEngine;
using Zenject;

public class UIRouter : MonoBehaviour
{
    private UIFactory _viewFactory;
    private UIControllerFactory _controllerFactory;

    [Inject]
    public void Construct(UIFactory viewFactory, UIControllerFactory controllerFactory)
    {
        _controllerFactory = controllerFactory;
        _viewFactory = viewFactory;
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
