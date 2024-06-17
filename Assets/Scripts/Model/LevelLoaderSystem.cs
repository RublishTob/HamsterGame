using System;
using System.Collections.Generic;

public class LevelLoaderSystem
{
    private SceneLoader _loader;
    public event Action OnLoadSceneIsDone;
    private int? _currentScene;
    public LevelLoaderSystem(SceneLoader loader, SceneUnlocker unlockerScene)
    {
        _loader = loader;
    }
    public void ChangeCurrentScene(int scene)
    {
        _currentScene = scene;
    }
    public void LoadingScene()
    {
        if(_currentScene == null)
        {
            return;
        }
        _loader.LoadScene((int)_currentScene);
    }
    public void LoadingSceneSave(LevelSave save)
    {
        _loader.LoadScene(save.Level);
    }
}
