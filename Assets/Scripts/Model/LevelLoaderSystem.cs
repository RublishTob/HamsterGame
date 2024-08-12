using System;

public class LevelLoaderSystem
{
    private SceneLoader _loader;
    private GameStateMachine _gameStateMachine;
    private SaveLoadSystem _saveLoadSystem;
    public event Action <int> OnLoadScene;
    public event Action <string> OnLoadSceneWithSave;
    private int? _currentScene;
    public LevelLoaderSystem(SceneLoader loader, GameStateMachine gameStateMachine, SaveLoadSystem saveLoadSystem)
    {
        _loader = loader;
        _gameStateMachine = gameStateMachine;
        _saveLoadSystem = saveLoadSystem;
    }
    public void ChangeCurrentScene(int scene)
    {
        _currentScene = scene;
    }
    public void LoadingScene()
    {
        _gameStateMachine.SwichState<LoadLevelState>();
        OnLoadScene?.Invoke((int)_currentScene);
        LoadCurrentScene();
    }
    public void LoadSceneWithSave(string nameSave)
    {
        _gameStateMachine.SwichState<LoadLevelState>();
        OnLoadSceneWithSave?.Invoke(nameSave);
        var save = _saveLoadSystem.ReadSave(nameSave);
        _currentScene = save.Level;
        LoadCurrentScene();
    }
    private void LoadCurrentScene()
    {
        if (_currentScene == null)
        {
            return;
        }
        _loader.LoadScene((int)_currentScene);
    }
}
