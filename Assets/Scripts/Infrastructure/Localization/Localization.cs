using System;
using System.Collections.Generic;

public class Localization: ILocalization
{
    private List<string> _languages;

    private Dictionary<string, string> _localizationText;

    public event Action TranslateText;

    public void ChangeLanguage(string language)
    {
        if (_languages == null) { return; }
        if (_languages.Contains(language) != true) { return; }

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
}