using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    private static MapController instance;
    public static MapController Instance
    {
        get
        {
            return instance;
        }
    }

    public UIController ui;
    public GameObject[] stages;
    public GameObject mainStages;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStage(int _index)
    {
        Debug.Log(_index);
        mainStages.SetActive(false);
        GameManager.isLobby = false;
        for (int i = 0; i < stages.Length; i++)
            stages[i].SetActive(false);
        stages[_index].SetActive(true);
        UIController.Instance.SetStageInfo(_index);
    }
}
