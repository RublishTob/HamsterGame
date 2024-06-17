using UnityEngine;
using Zenject;

public abstract class WalletController : MonoBehaviour
{
    protected IWalletRepository _wallet;

    [Inject]
    public void Construct(IWalletRepository wallet)
    {
        _wallet = wallet;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerViewDetect>() != null)
        {
            AddCoin();
        }
    }
    public abstract void AddCoin();
}
