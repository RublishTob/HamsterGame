using UnityEngine;
using Zenject;

public class LevelProgressWatcher : MonoBehaviour
{
    private LevelStateMachine _stateMachine;
    private LevelProgressService _levelProgressService;
    private Counter _counter;

    [Inject]
    public void Construct(LevelStateMachine stateMachine, LevelProgressService levelProgressService, Counter counter)
    {
        _stateMachine = stateMachine;
        _levelProgressService = levelProgressService;
        _levelProgressService.Watcher = this;
        _stateMachine.StartState<StartLevel>();
        _counter = counter;
    }
    private void Update()
    {
        if (_counter.Seconds <= 0)
        {
            _stateMachine.SwichState<LevelLoose>();
        }
    }
    private void OnDisable()
    {
        _levelProgressService.Watcher = null;
    }

}
