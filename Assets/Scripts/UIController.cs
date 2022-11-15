using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public float animTime = 2;
    private Image fadeImage;

    private float start = 1f;
    private float end = 0f;
    private float time = 0f;

    public bool stopIn = false;
    public bool stopOut = true;

    private void Awake()
    {
        fadeImage = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stopIn==false && time <=2)
        {
            PlayFadeIn();
        }
        if(stopOut == false && time <= 2)
        {
            PlayFadeOut();
        }

        if(time>=2 && stopOut==false)
        {
            stopIn = true;
            time = 0f;
            //Debug.Log("StopIn");
        }
        if(time>=2 && stopOut==false)
        {
            stopIn = false;
            stopOut = true;
            time = 0f;
            //Debug.Log("StopOut");
        }
    }

    void PlayFadeIn()
    {
        time += Time.deltaTime / animTime;

        Color color = fadeImage.color;
        color.a = Mathf.Lerp(start, end, time);
        fadeImage.color = color;
    }

    void PlayFadeOut()
    {
        time += Time.deltaTime / animTime;

        Color color = fadeImage.color;
        color.a = Mathf.Lerp(start, end, time);
        fadeImage.color = color;
    }
}
