
public class SkinSelector : IShopItemVisitor
{
    IPersistentData _persistentData;

    public SkinSelector(IPersistentData persistentData)
    {
        _persistentData = persistentData;
    }
    public bool IsSelected { get; private set; }

    public void Visit(ShopItem item)
    {
        Visit((dynamic)item);
    }

    public void Visit(CharacterSkinItem item)
    {
        _persistentData.PlayerData.SelectedSkinCharacter = item.SkinType;
    }

    public void Visit(HouseSkinItem item)
    {
        _persistentData.PlayerData.SelectedSkinHouse = item.SkinType;
    }
}
