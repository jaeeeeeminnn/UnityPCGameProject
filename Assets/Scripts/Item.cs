using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{ 

    static string[] itemNames =
    {
        "Key"
    };

    static Sprite[] itemSprites;

    public int itemCode;
    public string itemName;
    public Sprite itemSprite;

    public Item(int _itemCode)
    {
        if(itemSprites == null)
        {
            itemSprites = Resources.LoadAll<Sprite>("Item");
            Debug.Log(itemSprites.Length);
        }

        itemCode = _itemCode;
        itemName = itemNames[_itemCode];
        itemSprite = itemSprites[_itemCode];
    }
}
