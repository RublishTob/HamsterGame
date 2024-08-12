using TMPro;
using UnityEngine;
using Zenject;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text _value;

    private IWalletRepository _wallet;

    [Inject]
    public void Construct(IWalletRepository wallet)
    {
        _wallet = wallet;

        UpdateValue(_wallet.Wallet.GetCurrentCois);

    }
    private void OnEnable()
    {
        _wallet.Wallet.CoinsChanged += UpdateValue;
    }

    private void OnDisable()
    {
        _wallet.Wallet.CoinsChanged -= UpdateValue;
    }
    private void UpdateValue(int value) => _value.text = value.ToString();
}
