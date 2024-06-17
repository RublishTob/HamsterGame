using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    public void SetAnimatorTrigger(string param)
    {
        _animator.SetTrigger(param);
    }
    public void SetAnimatorBool(string param, bool isActive)
    {
        _animator.SetBool(param, isActive);
    }
    public void SetAnimatorFloat(string param, float value)
    {
        _animator.SetFloat(param, value);
    }
}
