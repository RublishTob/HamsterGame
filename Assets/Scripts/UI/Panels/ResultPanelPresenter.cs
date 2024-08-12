
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultPanelPresenter : IPanel
{
    private ResultPanelView _view;
    private LocalizationSystem _localization;
    private ResultBackgroundContent _backgroundContent;
    private GameStateMachine _gameStateMachine;
    private StateLevelData _levelData;
    private SoundSystem _soundSystem;
    private UIRouter _router;
    private LevelLoaderSystem _loaderSystem;

    private string Loose = "Loose";
    private string Win = "Win";

    private string[] Strings = { "Score", "StartNew", "Exit" };

    private bool IsSuccess;
    public string Id { get; private set; }

    public ResultPanelPresenter(ResultPanelView view, UIRouter router, LevelLoaderSystem loaderSystem, SoundSystem soundSystem, StateLevelData levelData, LocalizationSystem localization, ResultBackgroundContent backgroundContent, GameStateMachine gameStateMachine, bool success, string id)
    {
        IsSuccess = success;
        Id = id;
        _view = view;
        _localization = localization;
        _levelData = levelData;
        _backgroundContent = backgroundContent;
        _gameStateMachine = gameStateMachine;
        _soundSystem = soundSystem;
        _loaderSystem = loaderSystem;
        _router = router;
    }

    public void Hide()
    {
        _view.Back.onClick.RemoveListener(OnBack);
        _view.NewGame.onClick.RemoveListener(Restart);
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
        _view.SetCountOfCoin((_levelData.CoinToken.Count * 5).ToString());
        _view.Back.onClick.AddListener(OnBack);
        _view.NewGame.onClick.AddListener(Restart);
        _view.gameObject.SetActive(true);
    }
    private void OnBack()
    {
        _soundSystem.Click();
        _gameStateMachine.SwichState<Menu>();
    }
    private void Restart()
    {
        _soundSystem.Click();
        _loaderSystem.ChangeCurrentScene(SceneManager.GetActiveScene().buildIndex);
        _loaderSystem.LoadingScene();
    }
    private void LoadGame()
    {
        _router.OpenPanel("LoadGame");
    }

    public void DisposeResourse()
    {
    }
}
