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

    public void AcquireItem(Item _item)
    {
        Debug.Log("Acquire ����");
        for(int i = 0; i < slots.Length; i++)
        {
            if(slots[i].item != null)
            {
                Debug.Log("������ �߰��Ϸ�1");
                slots[i+1].AddItem(_item);
            }
        }
        for(int i = 0;i<slots.Length;i++)
        {
            if(slots[i].item == null)
            {
                Debug.Log("������ �߰� �Ϸ�");
                slots[i].AddItem(_item);
                return;
            }
        }
    }
}
