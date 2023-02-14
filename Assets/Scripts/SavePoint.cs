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
            DataManager.Instance.data.isSavePoint[GameManager.Instance.stageIndex] = true;
            DataManager.Instance.data.savePoint = savePosition.position;
            Debug.Log("SavePoint Ãæµ¹!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
