using UnityEngine;

public class CoinController : WalletController
{
    [SerializeField] private CoinView _coin;
    public override void AddCoin()
    {
        _wallet.Wallet.AddCoins(5);
        _coin.AddCoin();
        _wallet.Save();
        Destroy(gameObject);
    }
}
