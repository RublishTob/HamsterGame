using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]

public class SoundGamePlay : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _sounds;

    [SerializeField] private AudioSource _audioSrc;
    [SerializeField] private AudioSource _audioSrc2;
    private float _volume = 1.0f;

    public void PlaySound(int clipNumber, float p1 = 1f, float p2 = 1.2f)
    {
        AudioClip clip = _sounds[clipNumber];
        _audioSrc.pitch = Random.Range(p1, p2);
        _audioSrc.PlayOneShot(clip, _volume);
    }
    public void PlaySoundAndRepeat(int clipNumber)
    {
        AudioClip clip = _sounds[clipNumber];
        _audioSrc2.clip = clip;
        _audioSrc2.loop = true;
        _audioSrc2.pitch = 1;
        _audioSrc2.volume = _volume;
        _audioSrc2.Play();
    }
    public void SetVolume(float volume)
    {
        _volume = volume; 
    }
}
