
public class ResultPanelPresenter : IPanel
{
    private ResultPanelView _view;
    private SuccessSystem _successSystem;
    private LocalizationSystem _localization;

    private string Loose = "Loose";
    private string Win = "Win";
    private string Score = "Score";
    private string Load = "LoadGame";
    private string StartNew = "StartNew";
    private string Exit = "ExitGame";

    private bool IsSuccess;
    public string Id => "ResultPanel";

    public ResultPanelPresenter(ResultPanelView view, SuccessSystem successSystem, LocalizationSystem localization)
    {
        _view = view;
        _successSystem = successSystem;
        _localization = localization;
    }

    public void Hide()
    {
        _view.gameObject.SetActive(false);
    }
    public void Show(string nameOfPanel)
    {
        if (nameOfPanel != Id)
        {
            return;
        }
        if(IsSuccess)
        {

        }
        else
        {

        }
        _view.gameObject.SetActive(true);
    }
}
