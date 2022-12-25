using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1ObController : MonoBehaviour
{
    public GameObject[] moveOb;
    Rigidbody2D rigid;
    public GameObject detectionArea; //첫번째 구역 trigger

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(detectionArea.)
        {
            for (int i = 0; i < moveOb.Length; i++)
            {
                moveOb[i].gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("감지 구역 확인");
        if(collision.gameObject.tag == "Player")
        {
            dropOb();
        }
        
    }

    public void dropOb()
    {
        for(int i = 0; i < moveOb.Length; i++)
        {
            moveOb[i].gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        }
        //rigid.isKinematic = false;
    }
}
