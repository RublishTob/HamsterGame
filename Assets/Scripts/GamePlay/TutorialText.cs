using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

public class TutorialText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private LocalizationSystem _localization;

    [Inject]
    public void Construct(LocalizationSystem localization)
    {
        _localization = localization;
        gameObject.SetActive(false);
        DOTween.Init();
    }
    public void Print()
    {   if(text == null) 
        {
            return;
        }
        gameObject.SetActive(true);
        DOTween.Sequence()
            .Append(transform.DOScale(1f, 1.0f))
            .Append(transform.DOScale(0.8f, 0.5f));

        text.text = _localization.GetString("Tutorial");
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
