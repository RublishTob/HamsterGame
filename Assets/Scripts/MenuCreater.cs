using UnityEngine;
using Zenject;

public class MenuCreater : MonoBehaviour
{
    [SerializeField] private MenuLayout _menulayout;
    [SerializeField] private PanelLayout _panelLayout;

    private DiContainer _container;

    [Inject]
    public void Construct(DiContainer container)
    {
        _container = container;
    }
    void Start()
    {
        _menulayout = Instantiate(_menulayout, gameObject.transform);
        _container.Inject(_menulayout);
        
        _panelLayout = Instantiate(_panelLayout, gameObject.transform);
        _container.Inject(_panelLayout);
    }
}
