using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{


    public void ToLoadingSceneChange()
    {
        SceneManager.LoadScene("Loading");
    }

    public void ToStartSceneChange()
    {
        SceneManager.LoadScene("Start");
    }
}
