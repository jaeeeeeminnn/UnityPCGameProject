using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int stageIndex = -1;

    public GameObject tutorial;
    public GameObject stageMap;
    public PlayerController player;
    public GameObject tutorialManager;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        isClearTutorial();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextStage()
    {
        stageIndex++;
    }

    //IEnumerator TutorialRoutine()
    //{
        //playerController.enabled = false;
    //}

    public void isClearTutorial()
    {
        Debug.Log("튜토리얼 체크 진입함");
        int tutorialDone = PlayerPrefs.GetInt("TutorialDone");
        Debug.Log(tutorialDone);
        if (tutorialDone == 0)
        {
            tutorial.SetActive(true);
            tutorialManager.SetActive(true);
            PlayerPrefs.SetInt("TutorialDone", 1);
            return;
        }
        else
        {
            stageMap.SetActive(true);
            //PlayerPrefs.SetInt("TutorialDone", 0);
            return;
        }



    }
}
