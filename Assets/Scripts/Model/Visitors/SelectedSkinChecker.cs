
public class SelectedSkinChecker : IShopItemVisitor
{
    IPersistentData _persistentData;

    public SelectedSkinChecker(IPersistentData persistentData)
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
        IsSelected = _persistentData.PlayerData.SelectedSkinCharacter == item.SkinType;
    }

    public void Visit(HouseSkinItem item)
    {
        IsSelected = _persistentData.PlayerData.SelectedSkinHouse == item.SkinType;
    }
}
