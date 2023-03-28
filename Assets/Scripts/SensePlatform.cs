using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensePlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(this.gameObject.tag == "Enemy" && collision.gameObject.tag == "Platform")
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
