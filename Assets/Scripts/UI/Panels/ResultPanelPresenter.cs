
public class ResultPanelPresenter : IPanel
{
    private ResultPanelView _view;
    private LocalizationSystem _localization;
    private ResultBackgroundContent _backgroundContent;
    private GameStateMachine _gameStateMachine;

    private string Loose = "Loose";
    private string Win = "Win";

    private string[] Strings = { "Score", "LoadGame", "StartNew", "ExitGame" };

    private bool IsSuccess;
    public string Id { get; private set; }

    public ResultPanelPresenter(ResultPanelView view, LocalizationSystem localization, ResultBackgroundContent backgroundContent, GameStateMachine gameStateMachine, bool success, string id)
    {
        IsSuccess = success;
        Id = id;
        _view = view;
        _localization = localization;
        _backgroundContent = backgroundContent;
        _gameStateMachine = gameStateMachine;
    }

    public void Hide()
    {
        _view.Back.onClick.RemoveListener(OnBack);
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
            _view.SetResultText(_localization.GetString(Win));
            _view.SetBackground(_backgroundContent.SuccessBackground);
        }
        else
        {
            _view.SetResultText(_localization.GetString(Loose));
            _view.SetBackground(_backgroundContent.LooseBackground);
        }
        for(int i = 0; i < _view.Textes.Count; i++)
        {
            string text = _localization.GetString(Strings[i]);
            _view.Textes[i].text = text;
        }
        _view.Back.onClick.AddListener(OnBack);
        _view.gameObject.SetActive(true);
    }
    private void OnBack()
    {
        _gameStateMachine.SwichState<Menu>();
    }
}
