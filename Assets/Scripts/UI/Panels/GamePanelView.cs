using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanelView : MonoBehaviour
{
    public event Action<int> ChooseLevel;

    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _transform;

    [SerializeField] private List<LevelView> _levels;

    [SerializeField] public Button ToGame;
    [SerializeField] public BackToMenu ButtonBack;

    public void InitLevelView(LevelViewConfig level)
    {
        var levelView = Instantiate(_prefab, _transform);
        LevelView view = levelView.GetComponent<LevelView>();
        view.OnLevelClick += ChoiseLevel;
        view.SetImage(level.levelImage);
        view.SetName(level.level);
        _levels.Add(view);
    }
    private void ChoiseLevel(int lvl)
    {
        ChooseLevel?.Invoke(lvl);
        Debug.Log($"–¿¡Œ“¿≈“ {lvl}");
    }

    private void OnDisable()
    {
        foreach (var level in _levels)
        {
            level.GetComponent<LevelView>().OnLevelClick -= ChooseLevel;
        }
        _levels.Clear();
    }
}
