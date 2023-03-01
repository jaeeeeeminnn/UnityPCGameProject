using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject key;

    [SerializeField]
    private QuickSlotController quickSlot;

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
            key.SetActive(false);
            quickSlot.AcquireItem(key.GetComponent<ItemPickup>().item);
        }
    }
}
