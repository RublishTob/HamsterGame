
using System;

public class SceneUnlocker
{
    public event Action<int> SceneUnlocked;

    private PersistentData _data;
    public SceneUnlocker(PersistentData data)
    {
        _data = data;
    }

    public void UnlockScene(int lvl)
    {
        _data.PlayerData.OpenLevel(lvl);
        SceneUnlocked.Invoke(lvl);
    }
}
