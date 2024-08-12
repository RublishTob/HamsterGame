
public class WalletRepository : IWalletRepository
{
    private DataLocalProvider _provider;
    private PersistentData _data;
    private Wallet _wallet;

    public Wallet Wallet {  get { return _wallet; } }

    public WalletRepository(DataLocalProvider provider, PersistentData data)
    {
        _data = data;
        _provider = provider;
        _wallet = new Wallet(_data);
    }

    public void Save()
    {
        _provider.SaveDataPlayer(_wallet.Data);
    }

}
