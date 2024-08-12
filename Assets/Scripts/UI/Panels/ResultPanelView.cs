using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanelView : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private TMP_Text _resultText;

    [SerializeField] private TMP_Text _count;

    [SerializeField] public Button Back;
    [SerializeField] public Button NewGame;

    [SerializeField] public List<TMP_Text> Textes;

    public void SetBackground(Sprite image)
    {
        _background.sprite = image;
    }
    public void SetCountOfCoin(string count)
    {
        _count.text = count;
    }
    public void SetResultText(string image)
    {
        _resultText.text = image;
    }
}
