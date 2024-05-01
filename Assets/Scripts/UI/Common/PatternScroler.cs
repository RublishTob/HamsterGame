using UnityEngine;
using UnityEngine.UI;

public class PatternScroler : MonoBehaviour
{
    private RawImage _pattern;

    [SerializeField, Range(0, 10)] private float _scrollSpeed;

    [SerializeField, Range(-1, 1)] private float _xDirection;
    [SerializeField, Range(-1, 1)] private float _yDirection;

    private void Awake()
    {
        _pattern = GetComponent<RawImage>();
    }
    private void Update()
    {
          _pattern.uvRect = new Rect(_pattern.uvRect.position + new Vector2(-_xDirection * _scrollSpeed, _yDirection * _scrollSpeed) * Time.deltaTime,_pattern.uvRect.size);
    }
}
