using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1ObController : MonoBehaviour
{
    public static EventBlock currentEvent;
    public GameObject showingPlatform;
    public Rigidbody2D rigid;
    //public GameObject detectionArea; //첫번째 구역 trigger

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
                case 0: //떨어지는 장애물
                    DropOb();
                    break;
                case 1: //특정 행위를 취했을 때 새로운 Platform이 생기는 이벤트
                    ShowPlatform();
                    break;
            }
        }
    }

    /// <summary>
    /// EventBlock type Code = 0인 장애물을 떨어트림
    /// </summary>
    public void DropOb()
    {
        rigid.gravityScale = 2.0f;

    }

    public void ShowPlatform()
    {
        showingPlatform.SetActive(true);
    }

    public void RemoveOb()
    {
        
    }

    public void RegeneratoryOb()
    {

    }

}
