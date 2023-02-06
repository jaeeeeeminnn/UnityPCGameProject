using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject go_SlotsParent;

    private Slot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �κ��丮�� �������� �߰��ϴ� �Լ�
    /// �κ��丮�� ����á�� �� �۾� �߰��ؾ���
    /// </summary>
    /// <param name="_item"></param>
    public void AcquireItem(Item _item)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(slots[i].item != null)
            {
                slots[i+1].AddItem(_item);
            }
        }
        for(int i = 0;i<slots.Length;i++)
        {
            if(slots[i].item == null)
            {
                slots[i].AddItem(_item);
                return;
            }
        }
    }

    /// <summary>
    /// �κ��丮�� ������ �̸��� _name�� �������� ã�� �Լ�
    /// </summary>
    /// <param name="_name"></param>
    /// <returns></returns>
    public bool searchItem(string _name)
    {
        for(int i=0; i<slots.Length; i++)
        {
            if(slots[i].item != null)
            {
                if (slots[i].item.itemName == _name)
                {
                    Debug.Log(slots[i].item.name);
                    return true;
                }
            }
            
        }
        return false;
    }
}
