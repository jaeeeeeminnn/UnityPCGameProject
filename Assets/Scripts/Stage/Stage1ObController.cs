using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1ObController : MonoBehaviour
{
    private static Stage1ObController instance;
    public static Stage1ObController Instance
    {
        get
        {
            return instance;
        }
    }

    public static EventBlock currentEvent;
    public GameObject showingPlatform;
    public Rigidbody2D rigid;

    private GameObject parentEventBlocksPos;
    private GameObject parentItemsPos;

    public List<Vector3> eventBlocksPos = new List<Vector3>();
    public List<Vector3> itemsPos = new List<Vector3>();
    //public GameObject detectionArea; //ù��° ���� trigger

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        parentEventBlocksPos = GameObject.Find("EventBlocks").gameObject;
        parentItemsPos = GameObject.Find("items").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentEvent != null)
        {
            switch(currentEvent.type)
            {
                case 0: //�������� ��ֹ�
                    DropOb();
                    break;
                case 1: //Ư�� ������ ������ �� ���ο� Platform�� ����� �̺�Ʈ
                    ShowPlatform();
                    break;
            }
        }
    }

    /// <summary>
    /// EventBlock type Code = 0�� ��ֹ��� ����Ʈ��
    /// </summary>
    public void DropOb()
    {
        rigid.gravityScale = 2.0f;

    }

    public void ShowPlatform()
    {
        showingPlatform.SetActive(true);
    }


    // �� �غ��� ��ֹ� �ǵ����� �׽�Ʈ
    //public void findObject()
    //{   
    //    for(int i = 0; i< parentEventBlocksPos.transform.childCount; i++)
    //    {
    //        eventBlocksPos.Add(parentEventBlocksPos.transform.GetChild(i).position);

    //        if(parentEventBlocksPos.transform.GetChild(i).gameObject.activeSelf == false)
    //        {
    //            parentEventBlocksPos.transform.GetChild(i).gameObject.SetActive(true);
    //        }
    //        else
    //        {
    //            parentEventBlocksPos.transform.GetChild(i).gameObject.SetActive(false);
    //        }
            
            
    //    }

    //    for(int i = 0;i< parentItemsPos.transform.childCount;i++)
    //    {
    //        itemsPos.Add(parentItemsPos.transform.GetChild(i).position);

    //        if (parentItemsPos.transform.GetChild(i).gameObject.activeSelf == false)
    //        {
    //            parentItemsPos.transform.GetChild(i).gameObject.SetActive(true);
    //        }
    //    }
    //}

    //public void GoBackOriginalPosition()
    //{
    //    findObject();

    //    for(int i = 0; i < parentEventBlocksPos.transform.childCount; i++)
    //    {
    //        parentEventBlocksPos.transform.GetChild(i).gameObject.transform.position = eventBlocksPos[i];
    //    }

    //    for(int i = 0; i< parentItemsPos.transform.childCount; i++)
    //    {
    //        parentItemsPos.transform.GetChild(i).gameObject.transform.position = itemsPos[i];
    //    }
    //}
}
