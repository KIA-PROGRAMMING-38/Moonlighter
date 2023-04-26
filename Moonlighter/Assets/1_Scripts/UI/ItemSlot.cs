using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    private ItemData _item;

    private Image _itemImage;
    private Color _itemColor = new Color(1, 1, 1, 1);

    private int Count;


    private void Awake()
    {
        _itemImage = transform.GetChild(0).GetComponent<Image>();
        _itemImage.sprite = _item.ItemImage;
        _itemImage.color = _itemColor;
    }
}
