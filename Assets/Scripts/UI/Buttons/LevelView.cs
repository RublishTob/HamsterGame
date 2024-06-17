using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LevelView : MonoBehaviour
{
    public event Action<int> OnLevelClick;

    public Button Button;
    [SerializeField] private Image _image;
    private int _name;
    private void OnEnable()
    {
        Button.onClick.AddListener(OnClick);
    }
    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnClick);
    }
    private void OnClick()
    {
        OnLevelClick?.Invoke(_name);
    }
    public void SetImage(Sprite image)
    {
        _image.sprite = image;
    }
    public void SetName(int level)
    {
        _name = level;
        Debug.Log(_name);
    }

}
