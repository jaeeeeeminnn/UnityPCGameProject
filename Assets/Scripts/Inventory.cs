using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item item; //ȹ���� ������
    public Image itemImage; //������ �̹���
    
    public void AddItem(Item _item) //�κ��丮�� ������ �߰�
    {
        item = _item;
        itemImage.sprite = item.itemImage;
    }

    public void ClearSlot() //�κ��丮���� ������ ����
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
