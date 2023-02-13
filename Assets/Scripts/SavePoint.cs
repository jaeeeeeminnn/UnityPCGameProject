using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    Transform savePosition;

    // Start is called before the first frame update
    void Start()
    {
        savePosition = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("SavePoint �浹!");
            Debug.Log(savePosition.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
