using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private static Slot instance;
    public static Slot Instance
    {
        get
        {
            return instance;
        }
    }

    public Item item; //ȹ���� ������
    public Image itemImage; //������ �̹���

    [SerializeField] 

    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    public void AddItem(int _itemCode) //�κ��丮�� ������ �߰�
    {
        item = DataPool.Instance.SearchItem(_itemCode);
        itemImage.sprite = item.itemSprite;
        SetColor(1);
    }

    //public void ClearSlot() //�κ��丮���� ������ ����
    //{
    //    item = null;
    //    itemImage.sprite = null;
    //    SetColor(0);
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
