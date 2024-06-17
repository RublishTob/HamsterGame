using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonView : MonoBehaviour
{
    public event Action<int> LoadedLevel;

    [SerializeField] private Image _backgroung;
    [SerializeField] private TMP_Text _name;

    private int _level;
    private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(LoadLevel);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(LoadLevel);
    }
    public void SetLevel(int level)
    {
        _level = level;
    }
    public void SetName(string name)
    {
        _name.text = name;
    }
    private void LoadLevel()
    {
        LoadedLevel.Invoke(_level);
    }
}
