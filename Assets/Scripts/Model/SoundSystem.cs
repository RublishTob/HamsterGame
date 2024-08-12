using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;


public class SoundSystem
{
    private IPersistentData _data;
    private IDataProvider _provider;
    public event Action OnClick;
    public SoundSystem( IPersistentData data, IDataProvider provider)
    {
        _data = data;
        _provider = provider;

        _sounds = new ReactiveCollection<AudioClip>();
        VolumeMusic = new ReactiveProperty<float>();

        ChangeVolume(_data.Settings.Volume);
    }
    public ReactiveProperty<float> VolumeMusic;
    private ReactiveCollection<AudioClip> _sounds;
    public void Click()
    {
        OnClick?.Invoke();
    }
    public void ChangeVolume(float value)
    {
        VolumeMusic.Value = value;
    }
    public void SaveChanges() 
    {
        _data.Settings.Volume = VolumeMusic.Value;
        _provider.Save();
    }
    public void ChangeListAudioClips(List<AudioClip> list)
    {
        _sounds.Clear();
        for (int i = 0; i < list.Count; i++)
        {
            _sounds.Add(list[i]);
        }
    }
}
