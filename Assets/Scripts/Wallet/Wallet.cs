using System;

public class Wallet
{
    public event Action<int> CoinsChanged;
    public PlayerData Data { get => _data; }

    private PlayerData _data;

    public Wallet(PlayerData data)
    {
        _data = data;
    }
    public void AddCoins(int coins)
    {
        if(coins < 0)
            throw new ArgumentOutOfRangeException(nameof(coins));

        _data.Coins += coins;

        CoinsChanged?.Invoke(_data.Coins);
    }
    public int GetCurrentCois { get => _data.Coins; }

    public bool IsEnough(int coins)
    {
        if(coins < 0) 
            throw new ArgumentOutOfRangeException(nameof(coins));

        return _data.Coins >= coins;
    }

    public void Spend(int coins)
    {
        if(coins < 0) 
            throw new ArgumentOutOfRangeException(nameof(coins));

        _data.Coins -= coins;

        CoinsChanged?.Invoke(_data.Coins);
    }
}
