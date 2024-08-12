using UniRx;

public class SoundMenuPresenter
{
    private DisposeManager _disposeManager;
    private SoundMenu _soundMenu;
    private SoundSystem _soundSystem;
    private CompositeDisposable _compositeDisposable = new CompositeDisposable();

    public SoundMenuPresenter(SoundMenu sound, SoundSystem soundSystem, DisposeManager disposeManager) 
    {
        _soundMenu = sound;
        _soundSystem = soundSystem;
        _disposeManager = disposeManager;
        _disposeManager.DisposeRes += Disable;
        Init();
    }
    public void Init()
    {
        _soundMenu.SetVolume(_soundSystem.VolumeMusic.Value);
        _soundSystem.VolumeMusic.Subscribe(value =>
        {
            _soundMenu.SetVolume(value);
        }).AddTo(_compositeDisposable);
    }
    public void Disable()
    {
        _disposeManager.DisposeRes -= Disable;
        _compositeDisposable.Clear();
    }
}
