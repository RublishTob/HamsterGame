
public interface IDataProvider
{
    public void Save();
    public bool TryLoadLocalization(string path);
    public IPersistentData PersistentData { get;}
}
