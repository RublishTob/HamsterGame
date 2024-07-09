using UnityEngine;
using Zenject;

public abstract class WalletController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerViewDetect>() != null)
        {
            AddCoin();
        }
    }
    public abstract void AddCoin();
}
