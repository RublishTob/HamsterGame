using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class LoadBarShower : MonoBehaviour
{
    [SerializeField] private Image LoadBar;
    [SerializeField] private TMP_Text LoadText;

    private float progress;

    private SceneLoader _sceneLoader;
    private CompositeDisposable _compositeDisposable = new CompositeDisposable();

    [Inject]
    public void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
        _sceneLoader.Progress.Subscribe(value =>
        {
            LoadBar.fillAmount = value;
            LoadText.text = "«¿√–”« ¿  " + string.Format("{0:0}%", value * 100);
            //ViewLoading();
        }).AddTo(_compositeDisposable);
        Debug.Log("LOAD BAR HAS CREATED");
    }
    //public void ViewLoading()
    //{
    //    LoadBar.fillAmount = progress;
    //    LoadText.text = "«¿√–”« ¿  " + string.Format("{0:0}%", progress * 100);
    //}
    public void DestroyThis()
    {
        Destroy(gameObject);
    }
    public void OnDestroy()
    {
        _compositeDisposable.Dispose();
    }
}
