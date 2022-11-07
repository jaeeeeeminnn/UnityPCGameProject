using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Text text_time;
    [SerializeField] [Header("Tutorials items")] TutorialItemController[] items;
    public TutorialManager tutorialManager;
    float time;

    private void Awake()
    {
        time = items[tutorialManager.itemIndex].timeToInput;
        Debug.Log(time);
    }

    // Start is called before the first frame update
    void Start()
    {
        //time = items[tutorialManager.itemIndex].timeToInput;
        //Debug.Log(time);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        text_time.text = ((int)time % 60).ToString();
    }
}
