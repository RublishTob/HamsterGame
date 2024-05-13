using System;
using System.Collections.Generic;

public class Localization: ILocalization
{
    private IPersistentData _data;
    private Dictionary<string, string> _localizationText;

    public event Action TranslateText;

    public Localization(IPersistentData data)
    {
        _data = data;
    }
    public void ChangeLanguage(string language)
    {
        LocalizationData localizatonData = _data.LocalizateData;
        if (language == "Ru")
        {
            _localizationText = localizatonData.Ru;
            TranstateAll();
        }
    }
    public string GetString(string key)
    {
        return _localizationText[key];
    }
    private void TranstateAll()
    {
        TranslateText?.Invoke();
    }
}