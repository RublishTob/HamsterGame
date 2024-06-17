using UnityEngine;

public class ChestController : WalletController
{
    [SerializeField] private ChestView _chest;
    public override void AddCoin()
    {
        _wallet.Wallet.AddCoins(10);
        _chest.AddCoin();
        _wallet.Save();
    }
}
