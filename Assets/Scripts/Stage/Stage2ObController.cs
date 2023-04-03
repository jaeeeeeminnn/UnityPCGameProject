using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2ObController : MonoBehaviour
{
    private static Stage2ObController instance;
    public static Stage2ObController Instance
    {
        get
        {
            return instance;
        }
    }

    public static EventBlock currentEvent;
    public GameObject showingPlatform;
    public Rigidbody2D rigid;
    //public GameObject detectionArea; //ù��° ���� trigger

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEvent != null)
        {
            switch (currentEvent.type)
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

}
