
using System.Linq;

public class OpenSkinChecker : IShopItemVisitor
{
    IPersistentData _persistentData;

    public OpenSkinChecker(IPersistentData persistentData)
    {
        _persistentData = persistentData;
    }
    public bool IsOpen { get; private set;}

    public void Visit(ShopItem item)
    {
        Visit((dynamic)item);
    }

    public void Visit(CharacterSkinItem item)
    {
        IsOpen = _persistentData.PlayerData.OpenCharacterSkins.Contains(item.SkinType);
    }

    public void Visit(HouseSkinItem item)
    {
        IsOpen = _persistentData.PlayerData.OpenHouseSkins.Contains(item.SkinType);
    }
}
