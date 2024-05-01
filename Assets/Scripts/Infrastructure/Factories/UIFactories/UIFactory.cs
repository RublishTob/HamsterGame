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
    public GameObject CreateButtonBackMenu()
    {
        var prefab = _assetProvider.LoadAsset(BackMenu);
        var backToMenu = (GameObject) Object.Instantiate(prefab, _panels.transform.parent);
        //_backToMenu = _container.InstantiatePrefab(prefab).GetComponent<BackToMenu>();
        //_container.InstantiateComponent<MenuView>(_menu.gameObject);
        //_container.Inject(_backToMenu);
        //_container.InjectGameObject(_backToMenu.gameObject);
        _container.InjectGameObject(backToMenu);
        return _backToMenu = backToMenu;
    }
    public GameObject CreateMenu(Vector3 transform)
    {
        var prefab = _assetProvider.LoadAsset(Menu);
        var menu = (GameObject) Object.Instantiate(prefab, transform, Quaternion.identity);
        menu.GetComponent<MenuView>().Construct();
        //_menu = _container.InstantiatePrefab(prefab).GetComponent<MenuView>();
        //_container.InstantiateComponent<MenuView>(_menu.gameObject);
        //_container.Inject(_menu);
        //_container.InjectGameObject(_menu.gameObject);
        return _menu = menu;
    }
    public GameObject CreateMenuPanels(Vector3 transform)
    {
        var prefab = _assetProvider.LoadAsset(Panels);
        var panels = (GameObject) Object.Instantiate(prefab, transform, Quaternion.identity);
        //_panels = _container.InstantiatePrefab(prefab).GetComponent<Panels>();
        //_container.InstantiateComponent<Panels>(_panels.gameObject).GetComponent<Panels>();
        //_container.Inject(_panels);
        panels.GetComponent<Panels>().Construct(_menu.GetComponent<MenuView>());
        //_container.InjectGameObject(_panels.gameObject);
        return _panels = panels;
    }
    public GameObject CreateLoadBar(Vector3 transform)
    {
        var prefab = _assetProvider.LoadAsset(LoadBar);
        var loadbar = (GameObject) Object.Instantiate(prefab, transform, Quaternion.identity);
        //var loadbar = _container.InstantiatePrefab(prefab).GetComponent<LoadBarShower>();
        //_container.Inject(loadbar);
        
        return loadbar;
    }
    public GameObject CreateNavigationMenu(Vector3 transform)
    {
        var prefab = _assetProvider.LoadAsset(Navigate);
        var navbar = (GameObject) Object.Instantiate(prefab, transform, Quaternion.identity);
        //var navbar = _container.InstantiatePrefab(prefab).GetComponent<Navigation>();
        //navbar.GetComponent<Navigation>().Construct(_panels, _menu);
        navbar.GetComponent<Navigation>().Construct(_panels, _menu, _backToMenu);
        navbar.GetComponent<Navigation>().Init(_menu);
        //_menu.GetComponent<MenuView>()._gameButton._button.onClick.AddListener(() => { navbar.GetComponent<Navigation>().OpenGamePanel(); }); 
        //_container.Inject(navbar);
        //_container.InjectGameObject(_panels.gameObject);
        return navbar;
    }
}
