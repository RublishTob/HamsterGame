
public class SkinUnlocker : IShopItemVisitor
{
    IPersistentData _persistentData;

    public SkinUnlocker(IPersistentData persistentData)
    {
        _persistentData = persistentData;
    }

    public void Visit(ShopItem item)
    {
        Visit((dynamic)item);
    }

    public void Visit(CharacterSkinItem item)
    {
        _persistentData.PlayerData.OpenCharacterSkin(item.SkinType);
    }

    public void Visit(HouseSkinItem item)
    {
        _persistentData.PlayerData.OpenHouseSkin(item.SkinType);
    }
}
