
using UnityEngine;
using Zenject;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _hamster1;
    [SerializeField] private GameObject _hamster2;
    [SerializeField] private GameObject _hamster3;
    [SerializeField] private GameObject _hamster4;


    [SerializeField] private PlayerView _prefab;
    [SerializeField] private PlayerFactory _factory;
    [SerializeField] private Transform _spawnTransform;

    private IPersistentData _data;
    private StateLevelData _stateLevelData;
    private DiContainer _container;
    private PlayerPresenter _presenter;
    private DisposeManager _disposeManager;
    private SaveLoadSystem _saveSystem;

    [Inject]
    public void Construct(StateLevelData stateLevelData, IPersistentData data, SaveLoadSystem saveSystem, DisposeManager disposeManager, DiContainer container)
    {
        _stateLevelData = stateLevelData;
        _saveSystem = saveSystem;
        _disposeManager = disposeManager;
        _data = data;
        _container = container;
    }

    private void Awake()
    {
        if (_stateLevelData == null)
        {
            Debug.Log("Õ≈“ ƒ¿ÕÕ€’ ƒÀﬂ «¿√–”« »");
        }
        var prefab = Instantiate(Create(), new Vector3((float)_stateLevelData.x, (float)_stateLevelData.y, (float)_stateLevelData.z), new Quaternion((float)_stateLevelData.x_rot, (float)_stateLevelData.y_rot, (float)_stateLevelData.z_rot, (float)_stateLevelData.w_rot));
        _container.InjectGameObject(prefab);


        //if (_stateLevelData.x != null||_stateLevelData.z != null)
        //{
        //    prefab.transform.position = new Vector3((float)_stateLevelData.x, (float)_stateLevelData.y , (float)_stateLevelData.z);
        //    prefab.transform.rotation = new Quaternion((float)_stateLevelData.x_rot, (float)_stateLevelData.y_rot, (float)_stateLevelData.z_rot, (float)_stateLevelData.w_rot);
        //}
        //else
        //{
        //    //prefab.transform.position = _spawnTransform.position;
        //    Debug.Log("DONT FIND PLAYER SPAWN POSITION");
        //}
        _presenter = new PlayerPresenter(_stateLevelData, prefab.GetComponent<PlayerViewDetect>(), _saveSystem, _disposeManager);
    }
    private GameObject Create()
    {
        switch (_data.PlayerData.SelectedSkinCharacter)
        {
            case (CharacterSkins)0: return _hamster1;

            case (CharacterSkins)1: return _hamster2;

            case (CharacterSkins)2: return _hamster3;

            case (CharacterSkins)3: return _hamster4;
        }
        return null;
    }
}
