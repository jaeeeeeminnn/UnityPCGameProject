using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1ObController : MonoBehaviour
{
    public static EventBlock currentEvent;
    public Rigidbody2D rigid;
    //public GameObject detectionArea; //ù��° ���� trigger

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentEvent != null)
        {
            switch(currentEvent.type)
            {
                case 0:
                    DropOb();
                    break;
            }
        }
    }

    public void DropOb()
    {
        rigid.gravityScale = 2.0f;

    }

    public void RemoveOb()
    {
        
    }
}
