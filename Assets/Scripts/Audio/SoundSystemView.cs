using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SoundSystemView : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _sounds;

    private AudioSource _audioSrc;
    private float _volume = 1.0f;

    private void Start()
    {
        _audioSrc = GetComponent<AudioSource>();
    }
    public void PlaySound(int clipNumber, bool destroyed = false, float p1 = 1f, float p2 = 1.2f)
    {
        AudioClip clip = _sounds[clipNumber];
        _audioSrc.pitch = Random.Range(p1, p2);
        _audioSrc.PlayOneShot(clip, _volume);
    }

    public void SetSoundClip(AudioClip clip)
    {
        _sounds.Add(clip);
    }
    public void SetVolume(float volume)
    {
        _volume = volume; 
    }
    public void ClearListOfSound()
    {
        _sounds.Clear();
    }

}
