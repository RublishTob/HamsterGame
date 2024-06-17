using UniRx;

public class SavePanelPresenter : IPanel
{
    private SavePanelView _view;
    private SaveLoadSystem _repository;
    private UIRouter _router;
    private StateLevelData _levelData;
    private PersistentData _data;
    private CompositeDisposable _compositeDisposable = new CompositeDisposable();
    public string Name { get; private set; }
    public SavePanelPresenter(SavePanelView view, SaveLoadSystem repository, UIRouter router, StateLevelData levelData, PersistentData data)
    {
        _view = view;
        _repository = repository;
        _levelData = levelData;
        _router = router;
        _data = data;
        _router.PanelEnable += Show;
        _router.MenuEnable += Hide;
    }
    public string Id { get => "SavePanel"; }
    private void OnBack()
    {
        _router.OpenMenu("SavePanel");
    }
    private void OnSave()
    {
        //_repository.Create(Name, SceneManager.sceneCount);
    }
    private void InputFieldChange()
    {
        Name = _view.NameSave.text;
    }
    private void UpdateView(LevelSave save)
    {
        _view.CreateSave(save.Name);
    }
    public void Show(string panel)
    {
        if(panel != "SavePanel")
        {
            return;
        }
        _repository.CreateLevel.Subscribe( saveLevel => 
        {
            UpdateView(saveLevel);

        }).AddTo(_compositeDisposable);

        _view.ButtonBack.OnBack += OnBack;
        _view.ButtonSave.OnClick += OnSave;
        _view.NameSave.onValueChanged.AddListener(delegate { InputFieldChange(); });

        if (_data.levelSaves.Count < 0)
        {
            return;
        }

        var allSaves = _repository.ReadAllSaves();

        foreach (var i in allSaves)
        {
            _view.CreateSave(i.Name);
        }
    }
    public void Hide()
    {
        _view.ButtonBack.OnBack -= OnBack;
        _view.ButtonSave.OnClick -= OnSave;
        _view.NameSave.onValueChanged.RemoveListener(delegate { InputFieldChange(); });
        _view.gameObject.SetActive(false);
        _compositeDisposable.Dispose();
    }

}
