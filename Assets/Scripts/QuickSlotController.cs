using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSlotController : MonoBehaviour
{

    [SerializeField] private Slot[] quickSlots;
    [SerializeField] private Transform tf_parent;

    private int selectedSlot;
    private int selectedSlotIndex = -1;
    [SerializeField] private GameObject go_SelectedImage;

    public SpriteRenderer playerHoldingItem;
    
    // Start is called before the first frame update
    void Start()
    {
        quickSlots = tf_parent.GetComponentsInChildren<Slot>();
        go_SelectedImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TryInputNumber();
    }

    private void TryInputNumber()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(!isCheckedSelected(0))
            {
                ChangeSlot(0);
                Excute(0);
            }
            else
            {
                go_SelectedImage.SetActive(false);
                RemoveSelected();
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!isCheckedSelected(1))
            {
                ChangeSlot(1);
                Excute(1);
            }
            else
            {
                go_SelectedImage.SetActive(false);
                RemoveSelected();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (!isCheckedSelected(2))
            {
                ChangeSlot(2);
                Excute(2);
            }
            else
            {
                go_SelectedImage.SetActive(false);
                RemoveSelected();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (!isCheckedSelected(3))
            {
                ChangeSlot(3);
                Excute(3);
            }
            else
            {
                go_SelectedImage.SetActive(false);
                RemoveSelected();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (!isCheckedSelected(4))
            {
                ChangeSlot(4);
                Excute(4);
            }
            else
            {
                go_SelectedImage.SetActive(false);
                RemoveSelected();
            }
        }
    }

    private void ChangeSlot(int _num)
    {
        SelectedSlot(_num);
    }

    public void RemoveSelected()
    {
        selectedSlotIndex = -1;
        PlayerController.Instance.holdingItem.SetActive(false);
    }

    private void SelectedSlot(int _num)
    {
        go_SelectedImage.SetActive(true);

        selectedSlot = _num;
        selectedSlotIndex = _num;
        
        go_SelectedImage.transform.position = quickSlots[selectedSlotIndex].transform.position;
    }

    private bool isCheckedSelected(int _selectedNum)
    {
        if (_selectedNum == selectedSlotIndex)
            return true;
        else
            return false;
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

    public void Excute(int _num)
    {
        if(quickSlots[_num].item != null)
        {
            PlayerController.Instance.holdingItem.SetActive(true);
            PlayerController.Instance.holdingItem.GetComponent<SpriteRenderer>().sprite = quickSlots[_num].item.itemImage;
        }
        else
        {
            PlayerController.Instance.holdingItem.SetActive(false);
            //PlayerController.Instance.holdingItem.GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
