using System;
using System.Collections.Generic;
using System.Linq;

public class LocalizationSystem: ILocalization
{
    private IPersistentData _data;
    private IDataProvider _provider;

    private Dictionary<string, string> _localizationText;

    private string _currentLanguage;
    private string[] _languages = { "Ru","Eng"};

    public event Action TranslateText;

    public LocalizationSystem(IPersistentData data, IDataProvider provider)
    {
        _data = data;
        _provider = provider;
    }
    public void ChangeLanguage(string language)
    {
        if(language == _currentLanguage) return;
        if (!_languages.Contains(language)) return;

        LoadLanguage(language);

        _data.Settings.Language = language;
        _provider.Save();

        TranstateAll();
    }
    public string GetString(string key)
    {
        return _localizationText[key];
    }
    private void TranstateAll()
    {
        TranslateText?.Invoke();
    }
    private void LoadLanguage(string lang)
    {
        LocalizationData localizatonData = _data.LocalizateData;

        if (lang == "Ru")
        {
            _localizationText = localizatonData.Ru;
        }
        else if (lang == "Eng")
        {
            _localizationText = localizatonData.Eng;
        }
    }
}