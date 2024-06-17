using UniRx;

public class SoundMenuPresenter
{
    private SoundMenu _soundMenu;
    private SoundSystem _soundSystem;

    private CompositeDisposable _compositeDisposable = new CompositeDisposable();
    public SoundMenuPresenter(SoundMenu sound, SoundSystem soundSystem) 
    {
        _soundMenu = sound;
        _soundSystem = soundSystem;
        Init();
    }
    public void Init()
    {
        _soundMenu.SetVolume(_soundSystem.Volume.Value);
        _soundSystem.Volume.Subscribe(value =>
        {
            _soundMenu.SetVolume(value);
        });
    }
}
