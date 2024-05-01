using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopContent",menuName = "Shop/ShopContent")]
public class ShopContent : ScriptableObject
{
    [SerializeField]  private List<CharacterSkinItem> _characterSkinItems = new List<CharacterSkinItem>();

    [SerializeField]  private List<HouseSkinItem> _houseSkinItems = new List<HouseSkinItem>();

    public IEnumerable<CharacterSkinItem> CharacterSkinItems => _characterSkinItems;
    public IEnumerable<HouseSkinItem> HouseSkinItems => _houseSkinItems;

    private void OnValidate()
    {
        var characterSkinsDuplicates = _characterSkinItems.GroupBy(item=>item.SkinType)
            .Where(array =>  array.Count() > 1);
        if (characterSkinsDuplicates.Count() > 1)
        {
            throw new InvalidOperationException(nameof(_characterSkinItems));
        }

        var houseSkinsDuplicates = _characterSkinItems.GroupBy(item => item.SkinType)
            .Where(array => array.Count() > 1);
        if (houseSkinsDuplicates.Count() > 1)
        {
            throw new InvalidOperationException(nameof(_characterSkinItems));
        }
    }
}
