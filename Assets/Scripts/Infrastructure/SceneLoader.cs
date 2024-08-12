using System;
using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoader : MonoBehaviour
{
    private UIRouter _router;
    private AsyncOperation _asyncOperation;
    public bool IsDone { get => _asyncOperation.isDone; }
    public FloatReactiveProperty Progress = new FloatReactiveProperty();

    [Inject]
    public void Construct(UIRouter router)
    {
        _router = router;
        _router.MainMenuEnable += RoutToMain;
    }
    public void LoadScene(int sceneId, Action onLoaded = null)
    {
        StartCoroutine(LoadCurrentScene(sceneId,onLoaded));
    }
    private void RoutToMain()
    {
        _router.MainMenuEnable -= RoutToMain;
        SceneManager.LoadSceneAsync(1);
    }
    private IEnumerator LoadCurrentScene(int sceneId, Action onLoaded = null)
    {
        yield return null;

        _asyncOperation = SceneManager.LoadSceneAsync(sceneId);

        _asyncOperation.allowSceneActivation = false;

        while (_asyncOperation.isDone != true)
        {
            Progress.Value = _asyncOperation.progress / 0.9f;
            if (_asyncOperation.progress >= 0.9f)
            {
                    _asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
        onLoaded?.Invoke();
    }
}
    
