using UnityEngine;
using Zenject;

public class SoundMenu : MonoBehaviour
{
    [SerializeField] private GameObject videoPrefab;
    private ChangeVideo _videoPlayer;

    [Inject]
    public void Construct()
    {
        _videoPlayer = Instantiate(videoPrefab, transform).GetComponent<ChangeVideo>();
    }
    public void SetVolume(float volume)
    {
        _videoPlayer.ChangeVolume(volume);
    }
}
