using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static bool gameIsPause = false;
    public GameObject menu;
    public SceneChange sceneChange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPause = false;
    }

    public void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0.0f;
        gameIsPause = true;
    }

    public void QuitGame()
    {

    }

    public void ToStartScreen()
    {
        
    }
}
