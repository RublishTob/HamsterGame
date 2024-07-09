using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CoinSpawner : MonoBehaviour
{
    private DiContainer _container;
    private RewardSystem _rewardSystem;
    private RewardFactory _rewardFactory;

    [SerializeField] private GameObject _prefab;
    [SerializeField] private List<Transform> _spawnPoints;

    private List<CoinController> _coins = new List<CoinController>();

    [Inject]
    public void Construct(RewardSystem rewardSystem, RewardFactory rewardFactory, DiContainer container)
    {
        _rewardSystem = rewardSystem;
        _rewardFactory = rewardFactory;
        _container = container;
        Spawn();
    }
    public void Spawn()
    {
        foreach (var i in _rewardSystem.CoinNotToken)
        {
            var view = Instantiate(_prefab, transform);
            _container.InjectGameObject(view);
            view.transform.position = _spawnPoints[i].position;
            CoinController coinPresenter = _rewardFactory.CreateCoinPresenter(view.GetComponent<CoinView>(), i);
            coinPresenter.Show();
            coinPresenter.CoinTaked += HideCoin;
            _coins.Add(coinPresenter); 
        }
    }
    private void HideCoin(int id)
    {
        _coins[id].Hide();
        _coins[id].CoinTaked -= HideCoin;
    }
}
