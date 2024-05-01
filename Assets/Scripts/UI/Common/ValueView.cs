using TMPro;
using UnityEngine;

public class ValueView: MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void SetPrice(string value)
    {
        _text.text = value.ToString();
    }
}
