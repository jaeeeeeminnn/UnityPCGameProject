using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public PlayerController player;
    //public GameObject informationText;
    public GameManager gameManager;

    [SerializeField] [Header("Tutorials items")] TutorialItemController[] items;
    int itemIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(items == null)
        {
            return;
        }
        if(items.Length == 0)
        {
            return;
        }

        foreach(var item in items)
        {
            item.gameObject.SetActive(false);
        }

        itemIndex = -1;
        ActiveNextItem();
    }

    public void ActiveNextItem()
    {
        if(itemIndex > -1 && itemIndex < items.Length)
        {
            items[itemIndex].gameObject.SetActive(false);
        }

        itemIndex++;

        if (itemIndex > -1 && itemIndex < items.Length)
        {
            items[itemIndex].gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void tutorialStart()
    {
        player.enabled = false;
    }

    
}
