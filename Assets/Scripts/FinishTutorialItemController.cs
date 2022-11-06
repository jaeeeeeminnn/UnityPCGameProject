using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTutorialItemController : TutorialItemController
{
    protected override void Run()
    {
        PlayerPrefs.SetInt("TutorialDone", 1);

        base.Run();
    }
}
