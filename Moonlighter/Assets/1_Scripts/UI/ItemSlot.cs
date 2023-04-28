using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemSlot : MonoBehaviour
{
    public ItemData ItemData;

    public Image ItemImage;
    public Text CountText;

    public int Count;

    private void Awake()
    {
        ItemImage = transform.GetChild(0).GetComponent<Image>();
        CountText = transform.GetChild(1).GetComponent<Text>();
    }

    public static void SwapItemSlot(ItemSlot origin, ItemSlot clone)
    {
        ItemSlot tmp = Instantiate(clone);
        clone.ItemData = origin.ItemData;
        clone.ItemImage.sprite = origin.ItemImage.sprite;
        clone.Count = origin.Count;
        clone.CountText.text = origin.CountText.text;
        origin.ItemData = tmp.ItemData;
        origin.ItemImage.sprite = tmp.ItemImage.sprite;
        origin.Count = tmp.Count;
        origin.CountText.text = tmp.CountText.text;
        Destroy(tmp);
    }


}
