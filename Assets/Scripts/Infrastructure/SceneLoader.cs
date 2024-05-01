using System;
using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public FloatReactiveProperty Progress = new FloatReactiveProperty();

    private AsyncOperation _asyncOperation;
    public bool IsDone { get => _asyncOperation.isDone; }

    public void LoadScene(int sceneId, Action onLoaded = null)
    {
        StartCoroutine(LoadCurrentScene(sceneId,onLoaded));
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
    
