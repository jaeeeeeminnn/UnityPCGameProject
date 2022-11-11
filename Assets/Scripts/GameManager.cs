using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int stageIndex;
    public int health;

    public GameObject stageMap;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextStage()
    {
        stageIndex++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Health Down
            HealthDown();
            Debug.Log("Ãß¶ô °¨ÁöµÊ");

            //Player Reposition
            collision.attachedRigidbody.velocity = Vector2.zero;
            collision.transform.position = new Vector3(0, 0, -1);


        }
    }

    public void HealthDown()
    {
        if(health > 1)
        {
            health--;
        }
        else
        {
            //Player Die Effact
            player.OnDie();
            //Result UI
            Debug.Log("Á×¾ú½À´Ï´Ù!");
            //Retry Button UI
        }
    }

}
