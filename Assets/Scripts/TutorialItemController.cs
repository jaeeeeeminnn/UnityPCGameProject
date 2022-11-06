using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialItemController : MonoBehaviour
{

    public enum ItemType
    {
        touch
    }

    [SerializeField] [Header("따라하기 아이템 종류")] ItemType itemType;
    [SerializeField] [Header("사용자 입력 대기까지 진행시간")] float timeToInput;
    [SerializeField] [Header("사용자 입력 대기 시 표시할 게임 오브젝트")] GameObject gameObjectToShow;

    bool isReadyToInput = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        Invoke("ShowGameObject", timeToInput);
    }

    // Update is called once per frame
    void Update()
    {
        if(isReadyToInput)
        {
            if(itemType == ItemType.touch)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    Run();
                }
            }
        }
    }
    virtual protected void Run()
    {
        if(gameObjectToShow == null)
        {
            return;
        }

        gameObjectToShow.SetActive(false);

        TutorialManager parentTutorialManager = parentTutorialManager = transform.parent.GetComponent<TutorialManager>();
        if(parentTutorialManager != null)
        {
            parentTutorialManager.ActiveNextItem();
        }

        Time.timeScale = 1.0f;
    }

    void ShowGameObject()
    {
        isReadyToInput = true;
        Time.timeScale = 0.0f;

        if(gameObjectToShow == null)
        {
            return;
        }

        gameObjectToShow.SetActive(true);
    }
}
