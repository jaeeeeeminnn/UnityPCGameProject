using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject key;
    public Item itemInfo;

    [SerializeField]
    private QuickSlotController quickSlot;

    // Start is called before the first frame update
    void Start()
    {
        itemInfo = key.GetComponent<ItemPickup>().item;
    }

    // Update is called once per frame
    void Update()
    {
        if(SensePlatform.itemState == true)
        {
            itemInfo.trigger.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        { 
            key.SetActive(false);
            quickSlot.AcquireItem(key.GetComponent<ItemPickup>().item);
        }
    }
}
