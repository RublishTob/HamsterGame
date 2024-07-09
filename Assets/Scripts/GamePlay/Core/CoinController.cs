
using System;

public class CoinController
{
    public event Action<int> CoinTaked;

    private CoinView _coin;
    private IWalletRepository _wallet;
    private RewardSystem _rewardSystem;

    public CoinController(CoinView coin, IWalletRepository wallet, RewardSystem rewardSystem, int id)
    {
        _coin = coin;
        _wallet = wallet;
        _rewardSystem = rewardSystem;
        Id = id;
    }
    public int Id { get; }

    public void Show()
    {
        _coin.gameObject.SetActive(true);
        _coin.CoinToken += AddCoin;
    }
    public void Hide()
    {
        _coin.gameObject.SetActive(false);
        _coin.CoinToken -= AddCoin;
    }

    public void AddCoin()
    {
        _wallet.Wallet.AddCoins(5);
        _rewardSystem.CoinTaked(Id);
        CoinTaked?.Invoke(Id);
        _wallet.Save();
    }
}
