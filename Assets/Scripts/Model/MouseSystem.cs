using UniRx;

public class MouseSystem
{
    private IPersistentData _data;
    private IDataProvider _provider;
    public MouseSystem(IPersistentData data, IDataProvider provider)
    {
        _data = data;
        _provider = provider;
    }
    public ReactiveProperty<float> MouseSense = new ReactiveProperty<float>();
    public ReactiveProperty<bool> IsMouseVisible = new ReactiveProperty<bool>();
    public void ChangeMouseSense(float mouseSense)
    {
        MouseSense.Value = mouseSense;
    }
    public void ChangeMouseVisible(bool isMouseVisible)
    {
        IsMouseVisible.Value = isMouseVisible;
    }
    public void SaveChanges()
    {
        _data.Settings.MouseSense = MouseSense.Value;
        _provider.Save();
    }
}
