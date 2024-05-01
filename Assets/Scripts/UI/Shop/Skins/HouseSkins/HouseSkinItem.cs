using UnityEngine;

[CreateAssetMenu(fileName = "HouseSkinItem", menuName = "Shop/HouseSkinItem")]
public class HouseSkinItem : ShopItem
{
    [field: SerializeField] public HouseSkins SkinType { get; private set; }
}
