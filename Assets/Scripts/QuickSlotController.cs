using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSlotController : MonoBehaviour
{
    [SerializeField] private Slot[] quickSlots;
    [SerializeField] private Transform tf_parent;

    private int selectedSlot;
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
            ChangeSlot(0);
            Excute(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeSlot(1);
            Excute(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeSlot(2);
            Excute(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeSlot(3);
            Excute(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ChangeSlot(4);
            Excute(4);
        }
    }

    private void ChangeSlot(int _num)
    {
        SelectedSlot(_num);

    }

    private void SelectedSlot(int _num)
    {
        go_SelectedImage.SetActive(true);

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
        //Debug.Log("���� ��");
        //DataManager.Instance.data.playerInventory = this;
        //DataManager.Instance.SaveGameData();

        return;

    }

    /// <summary>
    /// �κ��丮�� ������ �̸��� _name�� �������� ã�� �Լ�
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
    /// �κ��丮�� ��� �������� �����ϴ� �Լ�
    /// </summary>
    public void RemoveAllItem()
    {
        for (int i = 0; i < quickSlots.Length; i++)
        {
            if (quickSlots[i].item != null)
            {
                Debug.Log("Item ���� �۾�");
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