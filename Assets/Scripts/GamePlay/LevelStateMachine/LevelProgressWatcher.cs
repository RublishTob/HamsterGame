using System.Collections;
using UnityEngine;
using Zenject;

public class LevelProgressWatcher : MonoBehaviour
{
    private LevelStateMachine _stateMachine;
    private LevelProgressService _levelProgressService;
    private Counter _counter;
    private StateLevelData _levelData;

    private bool isStart = false;

    [Inject]
    public void Construct(LevelStateMachine stateMachine, LevelProgressService levelProgressService, Counter counter, StateLevelData levelData)
    {
        _stateMachine = stateMachine;
        _levelProgressService = levelProgressService;
        _levelProgressService.Watcher = this;
        _stateMachine.StartState<StartLevel>();
        _counter = counter;
        _levelData = levelData;
        _counter.CountIsOver += Loose;
    }
    private void OnEnable()
    {
        Debug.Log($"Собрано {_levelData.CoinToken.Count} монет");
    }
    private void Update()
    {
        if(isStart)
        {
            if (_levelData.CoinToken.Count >= 2)
            {
                isStart = false;
                _stateMachine.SwichState<LevelWin>();
            }
            if (_counter.IsCountOver)
            {
                isStart = false;
                Loose();
            }
        }
    }
    public void Loose()
    {
        StartCoroutine(Count());
    }

    private IEnumerator Count()
    {
        _stateMachine.SwichState<LevelLoose>();
         yield return new WaitForSeconds(1f);
    }

    public void StartWatchCounter()
    {
        isStart = true;
    }

    private void OnDisable()
    {
        _counter.CountIsOver -= Loose;
        _levelProgressService.Watcher = null;
    }

}
