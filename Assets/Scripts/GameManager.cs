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
    public GameObject[] Stages;
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

    public void ClearStage()
    {
        //수정해야함
        //Change Stage
        if(stageIndex < Stages.Length-1)
        {
            Stages[stageIndex].SetActive(false);
            stageIndex++;
            stageMap.SetActive(true);
            //Stages[stageIndex].SetActive(true);
            UIController.Instance.Fade("Clear");
            PlayerReposition();
        }
        else
        {
            Time.timeScale = 0.0f;
            Debug.Log("게임 클리어!");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Player Reposition
            if(health > 1)
            {
                PlayerReposition();
            }

            //Health Down
            HealthDown();
            Debug.Log("추락 감지됨");
        }
    }

    void PlayerReposition()
    {
        player.transform.position = new Vector3(0, 0, -1);
        player.VelocityZero();
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
            Debug.Log("죽었습니다!");
            //Retry Button UI
        }
    }

     
    }


