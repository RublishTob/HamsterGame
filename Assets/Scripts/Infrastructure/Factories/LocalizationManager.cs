using System;
using System.Collections.Generic;

public class LocalizationManager: ILocalization
{
    private Dictionary<string, string> _localization;

    public event Action TranslateText;

    public string GetString(string key)
    {
        return _localization[key];
    }
    public void TranstateAll(string key)
    {
        TranslateText?.Invoke();
    }
}