using UniRx;
using UnityEngine;

public class VideoSystem
{
    private IPersistentData _data;
    private IDataProvider _provider;
    public VideoSystem(IPersistentData data, IDataProvider provider)
    {
        _data = data;
        _provider = provider;
        Resolution = new ReactiveProperty<int>();
    }
    public ReactiveProperty<int> Resolution;

    public void ChangeResolution(int resolution)
    {
        Resolution.Value = resolution;
    }
    public void SaveChanges()
    {
        _data.Settings.Resolution = Resolution.Value;
        _provider.Save();
    }
}
