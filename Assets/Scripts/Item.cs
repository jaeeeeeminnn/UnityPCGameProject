using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    int itemtype; //�������� ������ �������ڵ�
    public Sprite itemImage; //������ �̹���

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
            Debug.Log("������ �浹");
            this.enabled = false;
            //Inventory.Instance.AddItem(this);
        }
    }
}
