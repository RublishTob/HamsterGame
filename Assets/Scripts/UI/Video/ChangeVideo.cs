using UnityEngine;
using UnityEngine.Video;

public class ChangeVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;

    [SerializeField] private VideoClip[] _clip;
    void Start()
    {
        _videoPlayer.isLooping = false;
        _videoPlayer.clip = _clip[0];
        _videoPlayer.Play();
        _videoPlayer.loopPointReached += ChangeVideoPlay;
    }
    private void ChangeVideoPlay(VideoPlayer vp)
    {
        _videoPlayer.isLooping = true;
        _videoPlayer.clip = _clip[_clip.Length - 1];
    }

    public void OnDisable()
    {
        _videoPlayer.loopPointReached -= ChangeVideoPlay;
    }

}
