using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    [SerializeField] private AudioClip[] _sounds;

    private AudioSource _audioSrc;

    private void Start()
    {
        _audioSrc = GetComponent<AudioSource>();
    }
    public void PlaySound(int clipNumber, float volume = 1f, bool destroyed = false, float p1 = 0.85f, float p2 = 1.2f)
    {
        AudioClip clip = _sounds[clipNumber];
        _audioSrc.pitch = Random.Range(p1, p2);
        _audioSrc.PlayOneShot(clip, volume);
    }

}
