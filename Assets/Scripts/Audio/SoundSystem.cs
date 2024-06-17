
using System.Collections.Generic;
using UniRx;
using UnityEngine;


public class SoundSystem
{
    private SoundSource _sourceSound;
    private IPersistentData _data;
    private IDataProvider _provider;

    private ReactiveCollection<AudioClip> _sounds;
    public SoundSystem( IPersistentData data, IDataProvider provider)
    {
        _data = data;
        _provider = provider;

        _sounds = new ReactiveCollection<AudioClip>();
        Volume = new ReactiveProperty<float>();

        //Volume.Value = _data.Settings.Volume;
        ChangeVolume(_data.Settings.Volume);
    }
    public ReactiveProperty<float> Volume;

    public void ChangeVolume(float value)
    {
        Volume.Value = value;
    }
    public void SaveChanges() 
    {
        _data.Settings.Volume = Volume.Value;
        _provider.Save();
    }
    public void ChangeListAudioClips(List<AudioClip> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            _sounds.Add(list[i]);
        }
    }
}
