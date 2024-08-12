
public class PlayerPresenter :ISavable
{
    private StateLevelData _stateLevelData;
    private PlayerViewDetect _playerView;
    private SaveLoadSystem _saveSystem;
    private DisposeManager _disposeManager;
    public PlayerPresenter(StateLevelData stateLevelData, PlayerViewDetect playerView, SaveLoadSystem saveSystem, DisposeManager disposeManager)
    {
        _stateLevelData = stateLevelData;
        _playerView = playerView;
        _saveSystem = saveSystem;
        _disposeManager = disposeManager;
        _disposeManager.DisposeRes += DisposeResurse;
        _saveSystem.SaveData += Save;
    }
    public void Save()
    {
        _stateLevelData.x = _playerView.transform.position.x;
        _stateLevelData.y = _playerView.transform.position.y;
        _stateLevelData.z = _playerView.transform.position.z;
        _stateLevelData.x_rot = _playerView.transform.rotation.x;
        _stateLevelData.y_rot = _playerView.transform.rotation.y;
        _stateLevelData.z_rot = _playerView.transform.rotation.z;
        _stateLevelData.w_rot = _playerView.transform.rotation.w;
    }
    public void DisposeResurse()
    {
        _saveSystem.SaveData -= Save;
        _disposeManager.DisposeRes -= DisposeResurse;
    }
}
