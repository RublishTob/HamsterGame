using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GamePanelView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private LoadBarShower _loadBar;
    private SceneLoader _sceneLoader;

    [Inject]
    public void Construct(SceneLoader loader)
    {
        _sceneLoader = loader;
        _button.onClick.AddListener(LoadLevel);
    }
    public void LoadLevel()
    {
        Debug.Log("CLICK");
        _loadBar.gameObject.SetActive(true);
        _sceneLoader.LoadScene(3);
        if (_sceneLoader.IsDone)
        {
            _loadBar.gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(LoadLevel);
    }
}
