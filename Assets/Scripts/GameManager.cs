using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int stageIndex;

    // Start is called before the first frame update
    void Start()
    {
        stageIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextStage()
    {
        stageIndex++;
    }
}
