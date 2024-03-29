using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private QuickSlotController playerQuickSlot;

    public int itemCode;
    public SpriteRenderer spriteRenderer;
    public Vector3 itemPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerQuickSlot = GameObject.Find("QuickSlots").GetComponent<QuickSlotController>();
        spriteRenderer.sprite = DataPool.items[itemCode].itemSprite;
        itemPosition = this.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            switch (itemCode)
            {
                case 0:
                    this.gameObject.SetActive(false);
                    playerQuickSlot.AcquireItem(0);
                    break;
            }
        }
        
    }

}
