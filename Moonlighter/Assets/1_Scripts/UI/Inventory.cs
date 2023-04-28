using UnityEngine;
using EnumValue;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    public ItemSlot[] items;

    private void Awake()
    {
        InventoryPresenter.OnGoToInventory -= RegisterInInventory;
        InventoryPresenter.OnGoToInventory += RegisterInInventory;
    }

    void RegisterInInventory(ItemData data)
    {
        for(int i = 0; i < items.Length; ++i)
        {
            if (items[i].ItemData != null && items[i].ItemData.ItemType == ItemType.Potion)
            {
                if (items[i].Count < 5)
                {
                    ++items[i].Count;
                    items[i].CountText.text = items[i].Count.ToString();
                    return;
                }
                else
                {
                    continue;
                }
            }

            if (items[i].ItemData == null)
            {
                items[i].ItemData = data;
                items[i].ItemImage.sprite = data.ItemImage;
                if (items[i].ItemData.ItemType == ItemType.Potion)
                {
                    ++items[i].Count;
                    items[i].CountText.text = items[i].Count.ToString();
                }
                return;
            }
        }

        
    }
}
