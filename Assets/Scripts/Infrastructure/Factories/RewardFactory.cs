
public class RewardFactory
{
    private IWalletRepository _wallet;
    private RewardSystem _rewardSystem;
    public RewardFactory(IWalletRepository wallet, RewardSystem rewardSystem)
    {
        _wallet = wallet;
        _rewardSystem = rewardSystem;
    }

    public CoinController CreateCoinPresenter(CoinView view, int id)
    {
        return new CoinController(view, _wallet, _rewardSystem, id);
    }
}
