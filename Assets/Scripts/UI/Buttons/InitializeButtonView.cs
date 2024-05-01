using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InitializeButtonView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [field: SerializeField] public Button Button { get; private set; }
    public void SetText(string text)
    {
        _text.text = text;
    }
    public void SetEnable(bool isEnable)
    {
        gameObject.SetActive(isEnable);
    }

}
