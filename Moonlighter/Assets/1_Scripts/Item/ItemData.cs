using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumValue;

[CreateAssetMenu(fileName = "ItemData", menuName = "Data/Item Data/Base Data")]
public class ItemData : ScriptableObject
{
    public Sprite ItemImage;

    public ItemType ItemType;
}
