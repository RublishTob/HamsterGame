
public class NavigateButtonPresenter : ButtonPresenter
{
    private UIRouter _router;
    private SoundSystem _soundSystem;
    public NavigateButtonPresenter(ButtonView view, SoundSystem soundSystem, UIRouter router, LocalizationSystem localization, string id) : base(view, localization, id)
    {
        _router = router;
        _soundSystem = soundSystem;
    }
    public override void Click()
    {
        _soundSystem.Click();
        _router.OpenPanel(Id);
    }

}
