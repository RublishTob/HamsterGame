
public class WalletRepository : IWalletRepository
{
    private DataLocalProvider _provider;
    private Wallet _wallet;

    public Wallet Wallet {  get { return _wallet; } }

    public WalletRepository(DataLocalProvider provider)
    {
        _provider = provider;
        _wallet = new Wallet(_provider.PersistentData.PlayerData);
    }

    public void Save()
    {
        _provider.SaveDataPlayer(_wallet.Data);
    }

}
