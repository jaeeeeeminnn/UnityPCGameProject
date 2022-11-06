using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialItemController : MonoBehaviour
{

    public enum ItemType
    {
        touch
    }

    [SerializeField] [Header("�����ϱ� ������ ����")] ItemType itemType;
    [SerializeField] [Header("����� �Է� ������ ����ð�")] float timeToInput;
    [SerializeField] [Header("����� �Է� ��� �� ǥ���� ���� ������Ʈ")] GameObject gameObjectToShow;

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
