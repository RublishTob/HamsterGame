using System.Collections.Generic;
using UniRx;

public class SettingPanelPresenter : IPanel
{
    private readonly string[] _keyLabels = { "Settings", "Volume", "Sensetiviti", "Language" };
    private readonly string[] _keyLangueges = { "Ru", "Eng","Fr","Ch" };

    private SettingPanelView _view;
    private UIRouter _router;
    private LocalizationSystem _localization;
    private SoundSystem _soundSystem;
    private MouseSystem _mouseSystem;
    private VideoSystem _videoSystem;
    private IPersistentData _data;
    private IDataProvider _provider;

    private List<BtnLangPresenter> _buttonLangPresenters;

    private CompositeDisposable _compositeDisposable = new CompositeDisposable();

    public SettingPanelPresenter(
        SettingPanelView view, 
        UIRouter router, 
        LocalizationSystem localization, 
        IPersistentData data, 
        IDataProvider provider, 
        SoundSystem soundSystem,
        MouseSystem mouseSystem,
        VideoSystem videoSystem)
    {
        _view = view;
        _router = router;
        _localization = localization;
        _data = data;
        _provider = provider;
        _soundSystem = soundSystem;
        _mouseSystem = mouseSystem;
        _videoSystem = videoSystem;

        _router.PanelEnable += Show;
        _router.MenuEnable += Hide;
        _buttonLangPresenters = new List<BtnLangPresenter>();
        _localization.TranslateText += OnLocalizePenelTextes;
        CreateButtonLanguage();
        OnLocalizePenelTextes();
        _view.Volume.onValueChanged.AddListener(delegate { ChangeVolumeSound(); }) ;
        _view.Resolution.onValueChanged.AddListener(delegate { ChangeResolution(); });
    }
    public string Id { get => "SettingsPanel"; }
    public void Show(string panel)
    {
        if (panel != "SettingsPanel")
        {
            return;
        }
        _view.gameObject.SetActive(true);
        _view.OnValueSaved += OnClick;
        _view.SetVolume(_data.Settings.Volume);
        _view.SetMouseSense(_data.Settings.MouseSense);
        _view.SetResolution(_data.Settings.Resolution);
    }
    public void Hide()
    {
        _view.OnValueSaved -= OnClick;
        _localization.TranslateText -= OnLocalizePenelTextes;
        _view.gameObject.SetActive(false);
        _compositeDisposable.Dispose();
    }
    private void OnButtonLanguageChange(string language)
    {
        _localization.ChangeLanguage(language);
        OnLocalizePenelTextes();
    }
    private void OnClick()
    {
        _router.OpenMenu("SettingsPanel");
        SaveValue();
    }
    private void CreateButtonLanguage()
    {
        for (int i = 0; i < _view.ButtonsOfLangueges.Length; i++)
        {
            var btn = new BtnLangPresenter(_view.ButtonsOfLangueges[i], _keyLangueges[i]);
            btn.OnLangChange += OnButtonLanguageChange;
            _buttonLangPresenters.Add(btn);
        }
    }
    private void OnLocalizePenelTextes()
    {
        for (int i = 0; i < _view.AllTextesOnThePanel.Count; i++)
        {
            _view.AllTextesOnThePanel[i].SetText(_localization.GetString(_keyLabels[i]));
        }
    }
    private void SaveValue()
    {
        _mouseSystem.ChangeMouseSense(_view.MouseSense.value);
        _mouseSystem.SaveChanges();
        _soundSystem.SaveChanges();
        _videoSystem.SaveChanges();
        _provider.Save();
    }
    private void ChangeVolumeSound()
    {
        _soundSystem.ChangeVolume(_view.Volume.value);
    }
    private void ChangeResolution()
    {
        _videoSystem.ChangeResolution(_view.Resolution.value);
    }
}
