using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextBlink : MonoBehaviour
{
    private static TextBlink instance;
    public static TextBlink Instance
    {
        get
        {
            return instance;
        }
    }

    Text flashingText;


    // Start is called before the first frame update
    void Start()
    {
        flashingText = GetComponent<Text>();
        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText()
    {
        while(true)
        {
            flashingText.text = "";
            yield return new WaitForSeconds(.5f);
            flashingText.text = "A key is required to clear.";
            yield return new WaitForSeconds(.5f);
        }
    }

}
