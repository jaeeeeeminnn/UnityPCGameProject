using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void ToLoadingSceneChange()
    {
        SceneLoad.LoadScene("GameScene");
    }

    public void ToStartSceneChange()
    {
        SceneLoad.LoadScene("Start");
    }

}
