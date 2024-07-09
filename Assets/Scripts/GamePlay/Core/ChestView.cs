using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ChestView : MonoBehaviour
{
    private const string ADD = "Add";

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void AddCoin()
    {
        animator.SetTrigger(ADD);
    }
}
