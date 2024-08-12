using DG.Tweening;
using UnityEngine;

public class EnemyRotateDam : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 4f;
    [SerializeField] private AudioClip _audioclip;
    [SerializeField] private AudioSource _audiosourse;

    private Sequence sequence;
    void Start()
    {
        sequence = DOTween.Sequence();

        sequence.Append(transform.DORotate(new Vector3(0, -360, 0), rotateSpeed, RotateMode.LocalAxisAdd).SetEase(Ease.Linear));
        sequence.SetLoops(-1);
        sequence.AppendCallback(() => PlaySound());
    }
    private void PlaySound()
    {
        _audiosourse.PlayOneShot(_audioclip);
    }
    public void OnDestroy()
    {
        sequence.Kill();
    }
}
