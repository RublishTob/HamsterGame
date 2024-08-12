using DG.Tweening;
using UnityEngine;

public class StoneEnemyMoveS : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _moveToPosition;
    [SerializeField] private float _duration = 1f;
    [SerializeField] private AudioClip _audioclip;
    [SerializeField] private AudioSource _audiosourse;
    private Sequence sequence;

    void Start()
    {
        _startPosition.transform.position = transform.position;

        sequence = DOTween.Sequence();

        sequence.Append(transform.DOMove(_moveToPosition.position, _duration));
        sequence.Append(transform.DOMove(_startPosition.position, _duration));
        sequence.SetLoops(-1);
        //sequence.AppendCallback(() => PlaySound());
    }
    //private void PlaySound()
    //{
    //    if (_audioclip == null)
    //    {
    //        return;
    //    }
    //    _audiosourse.PlayOneShot(_audioclip);
    //}
    public void OnDestroy()
    {
        sequence.Kill();
    }
}
