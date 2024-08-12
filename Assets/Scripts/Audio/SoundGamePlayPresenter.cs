using Zenject;
using UniRx;

public class SoundGamePlayPresenter
{
    private SoundGamePlay _view;
    private DisposeManager _disposeManager;
    private SoundSystem _soundSystem;
    private CompositeDisposable _compositeDisposable = new CompositeDisposable();
    public SoundGamePlayPresenter(SoundGamePlay view, DisposeManager disposeManager, SoundSystem soundSystem)
    {
        _view = view;
        _disposeManager = disposeManager;
        _disposeManager.DisposeRes += DisposeResourses;
        _soundSystem = soundSystem;

        _view.SetVolume(_soundSystem.VolumeMusic.Value);

        _soundSystem.VolumeMusic.Subscribe(value =>
        {
            _view.SetVolume(value);
        }).AddTo(_compositeDisposable);
    }

    private void DisposeResourses()
    {
        _compositeDisposable.Dispose();
        _disposeManager.DisposeRes -= DisposeResourses;
    }

}
