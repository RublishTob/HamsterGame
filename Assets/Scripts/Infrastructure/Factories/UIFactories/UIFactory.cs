using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class UIFactory : MonoBehaviour
{
    private const string Root = "Prefabs/Root";
    private const string Panels = "Prefabs/Panels";
    private const string Menu = "Prefabs/Menu";
    private const string Button = "Prefabs/Button";
    private const string LoadPanel = "Prefabs/LoadPanel";
    private const string GamePanel = "Prefabs/NewGamePanel";
    private const string SettingsPanel = "Prefabs/SettingsPanel";
    private const string Load = "Prefabs/Load";

    private IAssetProvider _assetProvider;

    private PanelLayout _panels;
    private MenuLayout _menu;
    private Canvas _root;
    private DiContainer _container;

    [Inject]
    public void Construct(IAssetProvider assetProvider, DiContainer container)
    {
        _assetProvider = assetProvider;
        _container = container;
    }

    public void CreateRoot(Vector3 transform)
    {
        var prefab = _assetProvider.LoadAsset(Root);
        _root = Instantiate(prefab, transform, Quaternion.identity).GetComponent<Canvas>();
    }

    public GameObject CreateLoadBar()
    {
        var prefab = _assetProvider.LoadAsset(Load);
        var loadbar = (GameObject)Instantiate(prefab, _root.transform);
        _container.InjectGameObject(loadbar);
        return loadbar;
    }
}
