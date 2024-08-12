using System;
using UniRx;
using UnityEngine.SceneManagement;

public class SavePanelPresenter : IPanel
{
    private readonly string[] _keyLabels = { "SaveGame", "Save" };

    private SavePanelView _view;
    private SaveLoadSystem _saveLoadSystem;
    private UIRouter _router;
    private LocalizationSystem _localization;
    private StateLevelData _levelData;
    private PersistentData _data;
    private SoundSystem _soundSystem;
    private CompositeDisposable _compositeDisposable = new CompositeDisposable();
    public string Name { get; private set; }
    public SavePanelPresenter(SavePanelView view, SoundSystem soundSystem, SaveLoadSystem repository, UIRouter router, StateLevelData levelData, PersistentData data, LocalizationSystem localization)
    {
        _view = view;
        _saveLoadSystem = repository;
        _levelData = levelData;
        _router = router;
        _data = data;
        _soundSystem = soundSystem;
        _localization = localization;
        Localization();
        _localization.TranslateText += Localization;

        foreach (var saves in _saveLoadSystem.LevelSaves)
        {
            UpdateView(saves);
        }
    }
    public string Id { get => "SavePanel"; }
    private void OnBack()
    {
        _soundSystem.Click();
        _router.OpenMenu("SavePanel");
    }
    public void Localization()
    {
        for (int i = 0; i < _view.AllTextes.Count; i++)
        {
            _view.AllTextes[i].SetText(_localization.GetString(_keyLabels[i]));
        }
    }
    private void OnSave()
    {
        _soundSystem.Click();
        if (Name == null)
        {
            return;
        }
        _saveLoadSystem.Create(Name, DateTime.Now, SceneManager.GetActiveScene().buildIndex);
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
        _saveLoadSystem.CreateLevel += UpdateView;

        _view.ButtonBack.OnBack += OnBack;
        _view.ButtonSave.OnClick += OnSave;
        _view.gameObject.SetActive(true);
        _view.NameSave.onValueChanged.AddListener(delegate { InputFieldChange(); });
    }
    public void Hide()
    {
        _view.NameSave.onValueChanged.RemoveListener(delegate { InputFieldChange(); });
        _view.ButtonBack.OnBack -= OnBack;
        _view.ButtonSave.OnClick -= OnSave;
        _saveLoadSystem.CreateLevel -= UpdateView;
        _compositeDisposable.Dispose();
        _view.gameObject.SetActive(false);
    }
    public void DisposeResourse()
    {
        _localization.TranslateText -= Localization;
    }

}
