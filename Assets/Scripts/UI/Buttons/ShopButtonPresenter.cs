
public class ShopButtonPresenter : ButtonPresenter
{
    private SceneLoader _sceneLoader;
    private GameStateMachine _gameStateMachine;
    private SoundSystem _soundSystem;
    public ShopButtonPresenter(ButtonView view, SceneLoader sceneLoader, LocalizationSystem localization, string id, GameStateMachine gameStateMachine, SoundSystem soundSystem) : base(view, localization, id)
    {
        _sceneLoader = sceneLoader;
        _gameStateMachine = gameStateMachine;
        _soundSystem = soundSystem;
    }
    public override void Click()
    {
        _soundSystem.Click();
        _gameStateMachine.SwichState<ShopState>();
        _sceneLoader.LoadScene(2);
    }
}
