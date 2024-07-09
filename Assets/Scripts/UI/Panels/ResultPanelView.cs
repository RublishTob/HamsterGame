using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanelView : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private TMP_Text _count;

    [SerializeField] private Button _back;
    [SerializeField] private Button _load;
    [SerializeField] private Button _newGame;

    [SerializeField] public List<TMP_Text> textes;

    public void SetBackground(Sprite image)
    {
        _background.sprite = image;
    }
    public void SetCountOfCoin(string count)
    {
        _count.text = count;
    }
}
