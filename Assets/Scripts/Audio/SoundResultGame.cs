using System.Collections.Generic;
using UnityEngine;

public class SoundResultGame : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _sounds;

    [SerializeField] private AudioSource _audioSrc;

    private float _volume = 1f;
    public void PlayLooseGame()
    {
        PlaySound(0);
    }
    public void PlayWinGame()
    {
        PlaySound(1);
    }
    private void PlaySound(int clipNumber, bool isloop = false)
    {
        AudioClip clip = _sounds[clipNumber];
        _audioSrc.loop = isloop;
        _audioSrc.pitch = 1;
        _audioSrc.PlayOneShot(clip, _volume);
    }
}
