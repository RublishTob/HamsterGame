
public interface IDataProvider
{
    public void Save();
    public bool TryLoadLocalization();
    public bool TryLoadData();
    public bool TryLoadConfig();
    public bool TryLoadSavesData();
    public IPersistentData PersistentData { get;}
}
