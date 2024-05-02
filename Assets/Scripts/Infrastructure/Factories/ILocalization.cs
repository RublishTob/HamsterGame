using System;

public interface ILocalization
{
    public event Action TranslateText;
    public string GetString(string key);
}
