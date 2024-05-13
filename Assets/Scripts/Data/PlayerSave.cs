using System.Collections.Generic;
using System;
using Newtonsoft.Json;

public class PlayerSave: IData
{
    private CharacterSkins _selectedSkinCharacter;
    private HouseSkins _selectedHouse;

    private List<CharacterSkins> _openCharacterSkins;
    private List<HouseSkins> _openHouseSkins;

    private int _coins;

    public PlayerSave()
    {
        _coins = 20000;

        _selectedSkinCharacter = CharacterSkins.Medium;
        _selectedHouse = HouseSkins.Usualy;

        _openCharacterSkins = new List<CharacterSkins>() { _selectedSkinCharacter };
        _openHouseSkins = new List<HouseSkins>() { _selectedHouse };
    }

    [JsonConstructor]
    public PlayerSave(int coins, CharacterSkins selectedSkinCharacter, HouseSkins selectedHouse, 
        List<CharacterSkins> openCharacterSkins, List<HouseSkins> openHouseSkins)
    {
        _selectedSkinCharacter = selectedSkinCharacter;
        _selectedHouse = selectedHouse;
        _openCharacterSkins = openCharacterSkins;
        _openHouseSkins = openHouseSkins;
        _coins = coins;
    }
     public IEnumerable<CharacterSkins> OpenCharacterSkins => _openCharacterSkins;
     public IEnumerable<HouseSkins> OpenHouseSkins => _openHouseSkins;

    public int Coins 
    { 
        get { return _coins; }

        set 
        { 
            if(value < 0)
            throw new ArgumentException(nameof(value));
            
            _coins = value; 
        }
    }
    public CharacterSkins SelectedSkinCharacter 
    {
        get => _selectedSkinCharacter; 
        set
        {
            _selectedSkinCharacter = value;
        }
    }
    public HouseSkins SelectedSkinHouse
    {
        get => _selectedHouse;
        set
        {
            _selectedHouse = value;
        }
    }
    public void OpenCharacterSkin(CharacterSkins characterSkins)
    {
        if(_openCharacterSkins.Contains(characterSkins))
            throw new ArgumentException(nameof(characterSkins));

        _openCharacterSkins.Add(characterSkins);
    }
    public void OpenHouseSkin(HouseSkins houseSkins)
    {
        if (_openHouseSkins.Contains(houseSkins))
            throw new ArgumentException(nameof(houseSkins));

        _openHouseSkins.Add(houseSkins);
    }

}
