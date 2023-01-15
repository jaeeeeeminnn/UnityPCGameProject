using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject key;

    [SerializeField]
    private Inventory theInventory;

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
            Debug.Log("Key Ãæµ¹");
            key.SetActive(false);
            Debug.Log(this.GetComponent<ItemPickup>().item);
            Debug.Log(theInventory);
            //Slot.Instance.AddItem(this.GetComponent<ItemPickup>().item);
            theInventory.AcquireItem(key.GetComponent<ItemPickup>().item);
        }
    }
}
