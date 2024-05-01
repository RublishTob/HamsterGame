using UnityEngine;
using NaughtyAttributes;
using Zenject;
using System.Collections;
using System;
using UniRx;

public class Navigation : MonoBehaviour
{
    private Panels _panels;
    private MenuView _menuView;
    private BackToMenu _backToMenu;
    private GameObject _menu;

    //private void Start()
    //{
    //    _backToMenu.OnBack += ShowMenu;
    //    _menuView.ToGame += OpenGamePanel;
    //    _menuView.LoadGame += () => OpenPanel("Load");
    //    _menuView.SettingsGame += () => OpenPanel("Settings");
    //}
    private void Start()
    {
        StartCoroutine(dd());
    }
    IEnumerator dd()
    {
        yield return new WaitForSeconds(1f);
        Debbbug();
    }

    private void Debbbug()
    {
        //_backToMenu.OnBack += ShowMenu;
        //_menuView.ToGame += OpenGamePanel;
        //_menuView.LoadGame += () => OpenPanel("Load");
        //_menuView.SettingsGame += () => OpenPanel("Settings");
        //_backToMenu._button.onClick.AddListener(OpenGamePanel);
        //_menuView.Debbbug();
    }
    public void Init(GameObject menu) => (_menuView = menu.GetComponent<MenuView>()).ToGame += OpenGamePanel;
    
        public void Construct(GameObject panels, GameObject menu, GameObject backToMenu)
    {
        //Сделать зависимость от GameObject а не от компонентов
        _menuView = menu.GetComponent<MenuView>();
        _panels = panels.GetComponent<Panels>();
        _backToMenu = backToMenu.GetComponent<BackToMenu>();
        ShowMenu();
        //EventBus.OnEvent += OpenGamePanel;
        backToMenu.GetComponent<BackToMenu>().OnBack += ShowMenu;
        menu.GetComponent<MenuView>().ToGame += OpenGamePanel;
        menu.GetComponent<MenuView>().LoadGame += () => OpenPanel("Load");
        menu.GetComponent<MenuView>().SettingsGame += () => OpenPanel("Settings");
    }
    [Button("Invoke")]
    public void OpenGamePanel()
    {
        OpenPanel("Game");
    }

    [Button("Invoke1")]
    public void MenuPanel()
    {
        ShowMenu();
    }
    public void OpenPanel(string name)
    {
        ShowPanels();
        _panels.ShowPanel(name);
    }
    public void ShowMenu()
    {
        _menuView.gameObject.SetActive(true);
        _panels.gameObject.SetActive(false);
        Debug.Log("ShowMenu");
    }
    private void ShowPanels()
    {
        _panels.gameObject.SetActive(true);
        _menuView.gameObject.SetActive(false);
        Debug.Log("ShowPanels");
    }
    private void OnDisable()
    {
        _backToMenu.OnBack -= ShowMenu;
        _menuView.ToGame -= OpenGamePanel;
        _menuView.LoadGame -= () => OpenPanel("Load");
        _menuView.SettingsGame -= () => OpenPanel("Settings");
    }
}
