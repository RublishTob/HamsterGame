using UnityEngine;
using Zenject;

public class HouseSpawner : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private GameObject _house1;
    [SerializeField] private GameObject _house2;

    private IPersistentData _data;

    [Inject]
    public void Construct(IPersistentData data)
    {
        _data = data;
        var prefab = Instantiate(Create());
        prefab.transform.position = transform.position;
    }
    private GameObject Create()
    {
        if(_data.PlayerData.SelectedSkinHouse == 0)
        {
            return _house1;
        }
        else
        {
            return _house2;
        }
    }
}
