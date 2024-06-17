using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class UIFactory
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

    private GameObject _panels;
    private GameObject _menu;
    private Canvas _root;
    private DiContainer _container;

    public UIFactory (IAssetProvider assetProvider, DiContainer container)
    {
        _assetProvider = assetProvider;
        _container = container;
    }
    public void CreateRoot(Vector3 transform)
    {
        var prefab = _assetProvider.LoadAsset(Root);
        _root = Object.Instantiate(prefab, transform, Quaternion.identity).GetComponent<Canvas>();
    }
    public void CreateMenuRoot()
    {
        var prefab = _assetProvider.LoadAsset(Menu);
        _menu = (GameObject) Object.Instantiate(prefab, _root.transform);
        _container.InjectGameObject(_menu);

    }
    public void CreatePanelsRoot()
    {
        var prefab = _assetProvider.LoadAsset(Panels);
        _panels = (GameObject) Object.Instantiate(prefab, _root.transform);
        _container.InjectGameObject(_panels);
    }
    public GameObject CreateButton()
    {
        var prefab = _assetProvider.LoadAsset(Button);
        var button = (GameObject)Object.Instantiate(prefab, _menu.transform);
        return button;
    }
    public GameObject CreatePanel(TypePanel type)
    {
        Object prefab = new();

        switch(type)
        {
            case TypePanel.NewGame:
                prefab = _assetProvider.LoadAsset(GamePanel);
                break;
            case TypePanel.Settings:
                prefab = _assetProvider.LoadAsset(SettingsPanel);
                break;
            case TypePanel.LoadGame:
                prefab = _assetProvider.LoadAsset(LoadPanel);
                break;
        }

        var panel = (GameObject)Object.Instantiate(prefab, _panels.transform);
        return panel;
    }

    public GameObject CreateLoadBar()
    {
        var prefab = _assetProvider.LoadAsset(Load);
        var loadbar = (GameObject)Object.Instantiate(prefab, _root.transform);
        _container.InjectGameObject(loadbar);
        return loadbar;
    }
}
