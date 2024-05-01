using UnityEngine;

public class ItemViewFactory : MonoBehaviour
{
    [SerializeField] private ShopItemView _characterItemViewPrefab;
    [SerializeField] private ShopItemView _houseItemViewPrefab;
    public ShopItemView Prefab { get; private set; }

    public ShopItemView Get(ShopItem item)
    {
        return Get((dynamic)item);
    }

    public ShopItemView Get(CharacterSkinItem item)
    {
        return _characterItemViewPrefab;
    }

    public ShopItemView Get(HouseSkinItem item)
    {
        return _houseItemViewPrefab;
    }
}
