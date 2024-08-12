using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SoundMenu : MonoBehaviour
{

    private ChangeVideo _videoPlayer;

    [Inject]
    public void Construct(ChangeVideo videoPlayer)
    {
        _videoPlayer = videoPlayer;
    }
    public void SetVolume(float volume)
    {
        _videoPlayer.ChangeVolume(volume);
    }
}
