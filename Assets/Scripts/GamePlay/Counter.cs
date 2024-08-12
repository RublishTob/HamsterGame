using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TMP_Text))]
public class Counter : MonoBehaviour
{
    private float _seconds;
    private bool _isCounterRun;
    private TMP_Text _count;
    public event Action CountIsOver;

    private bool _isCountOver;
    public bool IsCountOver => _isCountOver;

    private StateLevelData _levelData;
    private SaveLoadSystem _saveSystem;
    private DisposeManager _disposeManager;
    private LevelProgressWatcher _watcher;

    private bool IsCounterRun{  get { return _isCounterRun; } }
    public float Seconds { get { return _seconds; } }

    [Inject]
    public void Construct(StateLevelData levelData, SaveLoadSystem saveSystem, DisposeManager disposeManager, LevelProgressWatcher watcher)
    {
        _levelData = levelData;
        _seconds = _levelData.Count;
        _saveSystem = saveSystem;
        _watcher = watcher;
        _saveSystem.SaveData += SaveCount;
        _disposeManager = disposeManager;
        _isCounterRun = _levelData.IsTimerRun;
        _disposeManager.DisposeRes += DisposeResourses;
        _count = GetComponent<TMP_Text>();
        gameObject.SetActive(false);
    }
    private void SaveCount()
    {
        _levelData.Count = _seconds;
        _levelData.IsTimerRun = _isCounterRun;
    }
    public void StopTimer()
    {
        _isCounterRun = false;
    }
    public void StartTimer()
    {
        _isCounterRun = true;
    }
    private void Update()
    {
        if (_seconds <= 0)
        {
            _isCountOver = true;
        }
    }
    public void StartCount()
    {
        gameObject.SetActive(true);
        if (_isCounterRun)
        {
            StartCoroutine(Count());
        }
    }
    private IEnumerator Count()
    {
        while (_seconds >= 0)
        {
            _seconds -= Time.deltaTime;
            _count.text = Mathf.RoundToInt(_seconds).ToString();
            yield return null;
        }
    }
    private void DisposeResourses()
    {
        _saveSystem.SaveData -= SaveCount;
        _disposeManager.DisposeRes-= DisposeResourses;
    }
}
