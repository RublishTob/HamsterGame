using UnityEngine;
using Zenject;

public class TutorialZoneCollider : MonoBehaviour
{
    private LevelStateMachine _stateMachine;
    private StateLevelData _stateLevelData;
    private bool _tutrialIsEntered;

    [Inject]
    public void Construct(LevelStateMachine stateMachine, StateLevelData stateLevelData)
    {
        _stateMachine = stateMachine;
        _stateLevelData = stateLevelData;
        _tutrialIsEntered = _stateLevelData.IsTimerRun;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_tutrialIsEntered)
        {
            return;
        }
        if (other.GetComponent<Collider>().gameObject.GetComponent<PlayerViewDetect>())
        {
            _stateMachine.SwichState<TutorialLevel>();
        }
        gameObject.SetActive(false);
    }
}
