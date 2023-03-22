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

    //public ItemObject pickupItem;

    public ItemObject selectedItem;
    public Vector3 selectedItemPos;

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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!IsCheckedSelected(0))
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
            if (!IsCheckedSelected(1))
            {
                ChangeSlot(1);
                //Excute(1);
            }
            else
            {
                go_SelectedImage.SetActive(false);
                RemoveSelected();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (!IsCheckedSelected(2))
            {
                ChangeSlot(2);
                //Excute(2);
            }
            else
            {
                go_SelectedImage.SetActive(false);
                RemoveSelected();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (!IsCheckedSelected(3))
            {
                ChangeSlot(3);
                //Excute(3);
            }
            else
            {
                go_SelectedImage.SetActive(false);
                RemoveSelected();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (!IsCheckedSelected(4))
            {
                ChangeSlot(4);
                //Excute(4);
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
        selectedItem.gameObject.SetActive(false);
        PlayerController.Instance.havingItem = false;
    }

    private void SelectedSlot(int _num)
    {
        go_SelectedImage.SetActive(true);

        selectedSlot = _num;
        selectedSlotIndex = _num;

        selectedItem = PlayerController.Instance.pickupItem;
        selectedItem.transform.SetParent(PlayerController.Instance.transform);
        selectedItem.transform.position = PlayerController.Instance.holdPos.position;
        selectedItem.GetComponent<BoxCollider2D>().isTrigger = false;
        //PlayerController.Instance.holdingItem = quickSlots[_num].gameObject;

        go_SelectedImage.transform.position = quickSlots[selectedSlotIndex].transform.position;
    }

    private bool IsCheckedSelected(int _selectedNum)
    {
        if (_selectedNum == selectedSlotIndex)
            return true;
        else
            return false;
    }

    public void OffSelectedImage()
    {
        go_SelectedImage.SetActive(false);
    }

    public void AcquireItem(int _itemCode)
    {
        for (int i = 0; i < quickSlots.Length; i++)
        {
            if (quickSlots[i].item == null)
            {
                quickSlots[i].AddItem(_itemCode);
                Debug.Log("아이템이 추가되었습니다.");
                break;
            }
            else
            {
                continue;
            }
        }
        //Debug.Log("저장 전");
        //DataManager.Instance.data.playerInventory = this;
        //DataManager.Instance.SaveGameData();

        return;

    }

    public void RemoveItem()
    {
        quickSlots[selectedSlot].ClearSlot();
    }

    /// <summary>
    /// 인벤토리에 아이템 이름이 _name인 아이템을 찾는 함수
    /// </summary>
    /// <param name="_name"></param>
    /// <returns></returns>
    //public bool SearchItem(string _name)
    //{
    //    for (int i = 0; i < quickSlots.Length; i++)
    //    {
    //        if (quickSlots[i].item != null)
    //        {
    //            if (quickSlots[i].item.itemName == _name)
    //            {
    //                Debug.Log(quickSlots[i].item.name);
    //                return true;
    //            }
    //        }

    //    }
    //    return false;
    //}

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
        if (quickSlots[_num].item != null)
        {
            selectedItem.gameObject.SetActive(true);
            //Debug.Log("Excute");
            PlayerController.Instance.havingItem = true;

        }
        else
        {
            //PlayerController.Instance.holdingItem.SetActive(false);
            //PlayerController.Instance.holdingItem.GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
