
public interface IShopItemVisitor
{
    public void Visit(ShopItem item);
    public void Visit(CharacterSkinItem item);
    public void Visit(HouseSkinItem item);
}
