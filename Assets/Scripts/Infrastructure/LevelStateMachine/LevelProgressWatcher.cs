using UnityEngine;
using Zenject;

public class LevelProgressWatcher : MonoBehaviour
{
    private LevelStateMachine _stateMachine;
    private LevelProgressService _levelProgressService;

    [Inject]
    public void Construct(LevelStateMachine stateMachine, LevelProgressService levelProgressService)
    {
        _stateMachine = stateMachine;
        _levelProgressService = levelProgressService;
        _levelProgressService.Watcher = this;
        _stateMachine.StartState<StartLevel>();
    }
    private void OnDisable()
    {
        _levelProgressService.Watcher = null;
    }

}
