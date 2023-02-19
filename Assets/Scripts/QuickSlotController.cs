using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSlotController : MonoBehaviour
{
    [SerializeField] private Slot[] quickSlots;
    [SerializeField] private Transform tf_parent;

    private int selectedSlot;
    [SerializeField] private GameObject go_SelectedImage;

    
    // Start is called before the first frame update
    void Start()
    {
        quickSlots = tf_parent.GetComponentsInChildren<Slot>();
        selectedSlot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TryInputNumber();
    }

    private void TryInputNumber()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            ChangeSlot(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeSlot(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeSlot(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            ChangeSlot(3);
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            ChangeSlot(4);
    }

    private void ChangeSlot(int _num)
    {
        SelectedSlot(_num);

    }

    private void SelectedSlot(int _num)
    {
        selectedSlot = _num;

        go_SelectedImage.transform.position = quickSlots[selectedSlot].transform.position;
    }

    public void AcquireItem(Item _item)
    {
        for (int i = 0; i < quickSlots.Length; i++)
        {
            if (quickSlots[i].item != null)
            {
                quickSlots[i + 1].AddItem(_item);
                break;
            }
            else
            {
                quickSlots[i].AddItem(_item);
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
    public bool SearchItem(string _name)
    {
        for (int i = 0; i < quickSlots.Length; i++)
        {
            if (quickSlots[i].item != null)
            {
                if (quickSlots[i].item.itemName == _name)
                {
                    Debug.Log(quickSlots[i].item.name);
                    return true;
                }
            }

        }
        return false;
    }

    /// <summary>
    /// 인벤토리의 모든 아이템을 삭제하는 함수
    /// </summary>
    public void RemoveAllItem()
    {
        for (int i = 0; i < quickSlots.Length; i++)
        {
            if (quickSlots[i].item != null)
            {
                Debug.Log("Item 삭제 작업");
                quickSlots[i].ClearSlot();
            }
        }
    }
}
