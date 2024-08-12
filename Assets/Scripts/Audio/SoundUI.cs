using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SoundUI : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _sounds;

    [SerializeField] private AudioSource _audioSrc;
    [SerializeField] private AudioSource _audioSrc2;

    private SoundSystem _soundSystem;

    private float _volume = 1.0f;

    [Inject]
    public void Construct(SoundSystem soundSystem)
    {
        _soundSystem = soundSystem;
    }
    private void OnEnable()
    {
        _soundSystem.OnClick += Play;
    }
    private void OnDisable()
    {
        _soundSystem.OnClick -= Play;
    }
    public void Play()
    {
        PlaySound(0);
    }
    public void PlaySound(int clipNumber, bool isloop = false)
    {
        AudioClip clip = _sounds[clipNumber];
        _audioSrc.loop = isloop;
        _audioSrc.pitch = 1;
        _audioSrc.PlayOneShot(clip, _volume);
    }
    public void PlaySoundAndRepeat(int clipNumber, bool isloop = true)
    {
        AudioClip clip = _sounds[clipNumber];
        _audioSrc.clip = clip;
        _audioSrc.loop = isloop;
        _audioSrc.pitch = 1;
        _audioSrc.volume = _volume;
        _audioSrc.Play();
    }
    public void SetSoundClip(AudioClip clip)
    {
        _sounds.Add(clip);
    }
    public void SetVolume(float volume)
    {
        _audioSrc.volume = volume;
    }
    public void ClearListOfSound()
    {
        _sounds.Clear();
    }
}
