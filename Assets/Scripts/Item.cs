using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    int itemtype; //아이템을 구별할 아이템코드
    public Sprite itemImage; //아이템 이미지

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("아이템 충돌");
            this.enabled = false;
            //Inventory.Instance.AddItem(this);
        }
    }
}
