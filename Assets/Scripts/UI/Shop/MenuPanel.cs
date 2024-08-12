using UnityEngine;
using Zenject;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private ButtonView buttonView;
    private UIPresenterFactory _presenterFactory;

    private ButtonPresenter buttonPresenter;

    [Inject]
    public void Construct(UIPresenterFactory presenterFactory)
    {
        _presenterFactory = presenterFactory;
        CreateButtons();
    }
    private void CreateButtons()
    {
        ButtonPresenter exitPresenter = _presenterFactory.CreateButtonContoller(buttonView, "ToMenu");
        buttonPresenter = exitPresenter;
        exitPresenter.Show();
    }

}
