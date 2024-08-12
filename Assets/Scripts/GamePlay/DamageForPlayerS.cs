using UnityEngine;
using Zenject;

public class DamageForPlayerS : MonoBehaviour
{
    private LevelProgressWatcher _watcher;

    [Inject]
    public void Construct(LevelProgressWatcher watcher)
    {
        _watcher = watcher;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_watcher != null)
        {
            if(other.gameObject.GetComponent<PlayerView>())
            {
                _watcher.Loose();
            }
        }
    }
}
