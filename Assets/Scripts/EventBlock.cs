using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class EventBlock : MonoBehaviour
{
    public int type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Stage1ObController.currentEvent = this;
        }
    }
}
