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

}
