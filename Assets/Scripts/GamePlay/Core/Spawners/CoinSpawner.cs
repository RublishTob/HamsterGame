using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class CoinSpawner : MonoBehaviour
{
    private DiContainer _container;
    private RewardSystem _rewardSystem;
    private RewardFactory _rewardFactory;
    private StateLevelData _stateLevelData;

    [SerializeField] private GameObject _prefab;
    [SerializeField] private List<Transform> _spawnPoints;

    [SerializeField] public List<CoinController> _coins = new List<CoinController>();

    [Inject]
    public void Construct(RewardSystem rewardSystem, RewardFactory rewardFactory, DiContainer container, StateLevelData stateLevelData)
    {
        _rewardSystem = rewardSystem;
        _rewardFactory = rewardFactory;
        _container = container;
        _stateLevelData = stateLevelData;
        Spawn();
    }
    public void Spawn()
    {
        foreach (var i in _stateLevelData.CoinNotToken)
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
        foreach (var coin in _coins)
        {
            if (coin.Id == id)
            {
                coin.Hide();
                coin.CoinTaked -= HideCoin;
                break;
            }
        }
    }
}
