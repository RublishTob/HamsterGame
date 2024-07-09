using System.Collections.Generic;
using UniRx;

public class StateLevelData
{
    public List<int> CoinToken = new List<int>();
    public List<int> CoinNotToken = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

    public ReactiveCollection<int> EnemyKilledId;
    public PlayerPositionRotation PositionPlayer { get; set; }

    public IntReactiveProperty DifficultyOfLevel = new();

    public IntReactiveProperty CoinTaked = new();
}
