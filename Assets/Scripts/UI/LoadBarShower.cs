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
            progress = value;
            ViewLoading();
        }).AddTo(_compositeDisposable);
    }
    public void ViewLoading()
    {
        LoadBar.fillAmount = progress;
        LoadText.text = "«¿√–”« ¿  " + string.Format("{0:0}%", progress * 100);
    }
}
