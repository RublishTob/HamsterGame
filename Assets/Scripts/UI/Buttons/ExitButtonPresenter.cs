
public class ExitButtonPresenter : ButtonPresenter
{
    private ExitGame _exit;
    private SoundSystem _soundSystem;
    public ExitButtonPresenter(ButtonView view, LocalizationSystem localization, ExitGame exit, string id, SoundSystem soundSystem) : base(view, localization, id)
    {
        _exit = exit;
        _soundSystem = soundSystem;
    }

    public override void Click()
    {
        _soundSystem.Click();
        _exit.OnExitGame();
    }
}
