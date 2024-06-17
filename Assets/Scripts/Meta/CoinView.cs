using UnityEngine;
using Zenject;

[RequireComponent(typeof(Animator))]
public class CoinView : MonoBehaviour
{
    //private SoundSystem _soundSystem;

    [Inject]
    public void Construct()//SoundSystem soundSustem)
    {
        //_soundSystem = soundSustem;
    }
    public void AddCoin()
    {
        //_soundSystem.PlaySound(0);
        Destroy(gameObject);
    }
}
