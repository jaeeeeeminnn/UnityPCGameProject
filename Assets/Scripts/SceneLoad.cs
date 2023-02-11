using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    static string nextScene;

    public Slider progressbar;
    public Text loadtext;
    
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loading");
        
    }

    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }
    
    IEnumerator LoadSceneProcess()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);
        operation.allowSceneActivation = false;

        float timer = 0f;

        while(!operation.isDone)
        {
            yield return null;
            if(operation.progress < 0.9f)
            {
                progressbar.value = operation.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressbar.value = Mathf.Lerp(0.9f, 1f, timer);
                if(progressbar.value >= 1f)
                {
                    loadtext.text = "Press SpaceBar";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        operation.allowSceneActivation = true;
                        Time.timeScale = 1.0f;
                        yield break;
                    }
                    
                }
            }
        }
    }
}
