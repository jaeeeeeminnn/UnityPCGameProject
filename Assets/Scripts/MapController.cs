using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        mainStages.SetActive(false);
        for (int i = 0; i < stages.Length; i++)
            stages[i].SetActive(false);
        stages[_index].SetActive(true);
    }
}
