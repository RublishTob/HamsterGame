using UnityEngine;
using Zenject;

public class TutorialZoneCollider : MonoBehaviour
{
    private LevelStateMachine _stateMachine;

    [Inject]
    public void Construct(LevelStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().gameObject.GetComponent<PlayerViewDetect>())
        {
            _stateMachine.SwichState<TutorialLevel>();
        }
        gameObject.SetActive(false);
    }
}
