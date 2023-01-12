using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item item; //획득한 아이템
    public Image itemImage; //아이템 이미지
    
    public void AddItem(Item _item) //인벤토리에 아이템 추가
    {
        item = _item;
        itemImage.sprite = item.itemImage;
    }

    public void ClearSlot() //인벤토리에서 아이템 삭제
    {
        item = null;
        itemImage.sprite = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
