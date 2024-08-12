using UnityEngine;
using UnityEngine.Video;
using Zenject;

public class ChangeVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;

    [SerializeField] private VideoClip[] _clip;

    [Inject]
    public void Construct()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.targetCamera = Camera.main;
        _videoPlayer.Play();
        _videoPlayer.isLooping = false;
        _videoPlayer.clip = _clip[0];
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
    public void ChangeVolume(float volume)
    {
        _videoPlayer.SetDirectAudioVolume(0, volume);
    }
    public void PlayVideo()
    {
        _videoPlayer.Play();
    }

}
