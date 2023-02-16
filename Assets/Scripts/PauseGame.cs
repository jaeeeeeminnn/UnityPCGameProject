using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static bool gameIsPause = false;
    public GameObject menu;
    public SceneChange sceneChange;
    [SerializeField]
    private GameObject theInventory;

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
        theInventory.SetActive(true);
    }

    public void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0.0f;
        gameIsPause = true;
        theInventory.SetActive(false);
    }

    public void QuitGame()
    {
        DataManager.Instance.SaveGameData();
        Application.Quit();
    }

    public void Save()
    {
        DataManager.Instance.SaveGameData();
    }

    public void ToStartScreen()
    {
        
    }
}
