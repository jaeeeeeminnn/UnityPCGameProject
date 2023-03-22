using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public QuickSlotController playerQuickSlot;

    public int itemCode;
    public SpriteRenderer spriteRenderer;
    public Vector3 itemPosition;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = DataPool.items[itemCode].itemSprite;
        itemPosition = this.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(itemCode)
        {
            case 0:
                PlayerController.Instance.pickupItem = this;
                this.gameObject.SetActive(false);
                playerQuickSlot.AcquireItem(0);
                Stage1ObController.Instance.ShowPlatform();
                break;
        }
    }

}
