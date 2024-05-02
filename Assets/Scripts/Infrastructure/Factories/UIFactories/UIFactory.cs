using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class UIFactory
{
    private const string LoadBar = "Prefabs/Load";
    private const string Panels = "Prefabs/Panels";
    private const string Menu = "Prefabs/Menu";
    private const string Navigate = "Prefabs/NavigationMenu";
    private const string BackMenu = "Prefabs/BackToMenu";
    private IAssetProvider _assetProvider;
    private DiContainer _container;

    private GameObject _panels;
    private GameObject _menu;
    public GameObject _backToMenu { get; private set; }

    public UIFactory (IAssetProvider assetProvider, DiContainer container)
    {
        _assetProvider = assetProvider;
        _container = container;
    }
    public GameObject CreateButton()
    {
        var prefab = _assetProvider.LoadAsset(BackMenu);
        var backToMenu = (GameObject)Object.Instantiate(prefab, _panels.transform.parent);
        return _backToMenu = backToMenu;
    }
    public GameObject CreatePanel()
    {
        var prefab = _assetProvider.LoadAsset(BackMenu);
        var backToMenu = (GameObject)Object.Instantiate(prefab, _panels.transform.parent);
        return _backToMenu = backToMenu;
    }

    public GameObject CreateButtonBackMenu()
    {
        var prefab = _assetProvider.LoadAsset(BackMenu);
        var backToMenu = (GameObject) Object.Instantiate(prefab, _panels.transform.parent);
        return _backToMenu = backToMenu;
    }
    public GameObject CreateMenu(Vector3 transform)
    {
        var prefab = _assetProvider.LoadAsset(Menu);
        var menu = (GameObject) Object.Instantiate(prefab, transform, Quaternion.identity);
        return _menu = menu;
    }
    public GameObject CreateMenuPanels(Vector3 transform)
    {
        var prefab = _assetProvider.LoadAsset(Panels);
        var panels = (GameObject) Object.Instantiate(prefab, transform, Quaternion.identity);
        return _panels = panels;
    }
    public GameObject CreateLoadBar(Vector3 transform)
    {
        var prefab = _assetProvider.LoadAsset(LoadBar);
        var loadbar = (GameObject) Object.Instantiate(prefab, transform, Quaternion.identity);
        return loadbar;
    }
    public GameObject CreateNavigationMenu(Vector3 transform)
    {
        var prefab = _assetProvider.LoadAsset(Navigate);
        var navbar = (GameObject) Object.Instantiate(prefab, transform, Quaternion.identity);
        return navbar;
    }
}
