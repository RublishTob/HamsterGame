
using System.Collections.Generic;

public class RewardSystem
{
    public IEnumerable<int> CoinToken => _data.CoinToken;
    public IEnumerable<int> CoinNotToken => _data.CoinNotToken;

    private StateLevelData _data;
    public RewardSystem(StateLevelData data)
    {
        _data = data;
    }
    public void CoinTaked(int coin)
    {
        _data.CoinToken.Add(coin);
        _data.CoinNotToken.Remove(coin);
    }

}
