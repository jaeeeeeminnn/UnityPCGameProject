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
        //DataManager.Instance.data.playerInventory = this;
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 인벤토리에 아이템을 추가하는 함수
    /// 인벤토리가 가득찼을 때 작업 추가해야함
    /// </summary>
    /// <param name="_item"></param>
    public void acquireItem(Item _item)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(slots[i].item != null)
            {
                slots[i+1].addItem(_item);
                break;
            }
            else
            {
                slots[i].addItem(_item);
                break;
            }
        }
        //Debug.Log("저장 전");
        //DataManager.Instance.data.playerInventory = this;
        //DataManager.Instance.SaveGameData();

        return;
        
    }

    /// <summary>
    /// 인벤토리에 아이템 이름이 _name인 아이템을 찾는 함수
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

    /// <summary>
    /// 인벤토리의 모든 아이템을 삭제하는 함수
    /// </summary>
    public void removeAllItem()
    {
        for(int i=0; i<slots.Length;i++)
        {
            if(slots[i].item != null)
            {
                Debug.Log("Item 삭제 작업");
                slots[i].clearSlot();
            }
        }
    }
}
