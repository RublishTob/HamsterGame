
public interface IDataProvider
{
    public void Save();
    public bool TryLoad();
    public IPersistentData PersistentData { get;}
}
