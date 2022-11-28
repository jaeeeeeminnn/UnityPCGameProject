using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private static UIController instance;
    public static UIController Instance
    {
        get
        {
            return instance;
        }
    }

    public static string situation;
    public Text deadCount;
    public Image[] FadeImages;
    float time = 0.0f;
    float F_time = 1.0f;

    public void Fade(string sit)
    {
        situation = sit;

        switch(situation)
        {
            case "settingMap":
                StartCoroutine(FadeProcess(situation, FadeImages[0]));
                break;
            case "dead":
                StartCoroutine(FadeProcess(situation, FadeImages[1]));
                break;
            case "Clear":
                StartCoroutine(FadeProcess(situation, FadeImages[2]));
                break;

        }

        

    }

    IEnumerator FadeProcess(string situation, Image _image)
    {
        if(situation == "dead")
            yield return new WaitForSeconds(1f);
        _image.gameObject.SetActive(true);
        time = 0.0f;
        Color alpha = _image.color;
        while(alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            _image.color = alpha;
            yield return null;
        }

        time = 0.0f;

        yield return new WaitForSeconds(1f);

        if(situation == "settingMap")
        {
            PlayerController.Instance.transform.position = Vector3.zero;
            MapController.Instance.SetStage(PortalManager.currentPortal.portalCode);
        }
        if(situation == "dead")
        {
            PlayerController.Instance.PlayerReplaced();
            deadCount.text = PlayerController.Instance.deathCount.ToString();
        }
        if(situation == "Clear")
        {

        }
        
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            _image.color = alpha;
            yield return null;
        }

        _image.gameObject.SetActive(false);

        yield return null;
    }


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //isFinishFade = false;
        deadCount.text = PlayerController.Instance.deathCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
