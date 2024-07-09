using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Animator))]
public class CoinView : MonoBehaviour
{
    public event Action CoinToken;
    private SoundGamePlay _soundSystem;

    [Inject]
    public void Construct(SoundGamePlay soundSustem)
    {
        _soundSystem = soundSustem;
    }
    public void AddCoin()
    {
        _soundSystem.PlaySound(0);
        CoinToken?.Invoke();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerViewDetect>() != null)
        {
            AddCoin();
        }
    }
}
