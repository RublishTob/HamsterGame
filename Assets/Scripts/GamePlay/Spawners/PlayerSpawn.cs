using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private PlayerView _prefab;
    [SerializeField] private PlayerFactory _factory;
    [SerializeField] private Transform _spawnTransform;

    private void Awake()
    {
        _prefab.transform.position = _spawnTransform.position;
        Instantiate(_prefab);
    }
}
