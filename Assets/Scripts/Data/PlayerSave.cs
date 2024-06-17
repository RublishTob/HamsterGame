using System.Collections.Generic;
using System;
using Newtonsoft.Json;

public class PlayerSave
{
    private List<CharacterSkins> _openCharacterSkins;
    private List<HouseSkins> _openHouseSkins;
    private List<int> _openLevel;
    public CharacterSkins SelectedSkinCharacter { get; set; }
    public HouseSkins SelectedSkinHouse { get; set; }
    public int Coins { get; set; }

    public PlayerSave()
    {
        Coins = 20000;

        SelectedSkinCharacter = CharacterSkins.Medium;
        SelectedSkinHouse = HouseSkins.Usualy;

        _openCharacterSkins = new List<CharacterSkins>() { SelectedSkinCharacter };
        _openHouseSkins = new List<HouseSkins>() { SelectedSkinHouse };
        _openLevel = new List<int>() { 3 };
    }

    [JsonConstructor]
    public PlayerSave(int coins, CharacterSkins selectedSkinCharacter, HouseSkins selectedHouse, 
        List<CharacterSkins> openCharacterSkins, List<HouseSkins> openHouseSkins)
    {
        SelectedSkinCharacter = selectedSkinCharacter;
        SelectedSkinHouse = selectedHouse;
        _openCharacterSkins = openCharacterSkins;
        _openHouseSkins = openHouseSkins;
        Coins = coins;
    }
     public IEnumerable<CharacterSkins> OpenCharacterSkins => _openCharacterSkins;
     public IEnumerable<HouseSkins> OpenHouseSkins => _openHouseSkins;

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
    public void OpenLevel(int lvl)
    {
        _openLevel.Add(lvl);
    }

}
