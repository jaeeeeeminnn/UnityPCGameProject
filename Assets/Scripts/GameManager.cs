using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int stageIndex = -1;

    public PlayerController playerController;
    public GameObject informationText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        if(stageIndex == -1)
        {
            Tutorial();
            //StartCoroutine("TutorialRoutine");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //playerController.enabled = false;
        //informationText.SetActive(true);
        //playerController.enabled = true;
        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        //{
            //informationText.SetActive(false);
        //}
    }

    public void NextStage()
    {
        stageIndex++;
    }

    //IEnumerator TutorialRoutine()
    //{
        //playerController.enabled = false;
    //}

    public void Tutorial()
    {
        Debug.Log("튜토리얼 진입함");
        playerController.enabled = false;
        informationText.SetActive(true);
        playerController.enabled = true;
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            informationText.SetActive(false);
        }
    }
}
