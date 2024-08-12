using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class LoadBarShower : MonoBehaviour
{
    [SerializeField] private Image LoadBar;
    [SerializeField] private TMP_Text LoadText;

    private string _id = "Load";
    private string _loadString;
    private float progress;

    LocalizationSystem _localization;
    private SceneLoader _sceneLoader;
    private CompositeDisposable _compositeDisposable = new CompositeDisposable();

    [Inject]
    public void Construct(SceneLoader sceneLoader, LocalizationSystem localization)
    {
        _sceneLoader = sceneLoader;
        _localization = localization;
        Localization();
        _sceneLoader.Progress.Subscribe(value =>
        {
            LoadBar.fillAmount = value;
            LoadText.text = $"{_loadString}  " + string.Format("{0:0}%", value * 100);

        }).AddTo(_compositeDisposable);
    }
    public void Localization()
    {
        _loadString = _localization.GetString(_id);
    }

    public void OnEnable()
    {
        if(_localization == null) return;

        _localization.TranslateText += Localization;
    }
    public void OnDisable()
    {
        _compositeDisposable.Dispose();
        _localization.TranslateText -= Localization;
    }
}
