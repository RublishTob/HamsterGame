using UnityEngine;
using UnityEngine.Video;

public class SoundMenu : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;

    public void SetVolume(float volume)
    {
        _videoPlayer.SetDirectAudioVolume(0, volume);
       
    }
}
