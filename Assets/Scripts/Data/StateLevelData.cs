using UniRx;

public class StateLevelData
{
    public ReactiveCollection<int> EnemyKilledId;
    public PlayerPositionRotation PositionPlayer { get; set; }

    public IntReactiveProperty DifficultyOfLevel = new();

    public IntReactiveProperty CoinTaked = new();
}
