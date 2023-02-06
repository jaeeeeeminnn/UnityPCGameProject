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

    public GameObject inventory;
    public static string situation;
    public Text deadCount;
    public Text stageInfo;
    public Text Required;
    public Image[] FadeImages;
    float time = 0.0f;
    float F_time = 1.0f;

    /// <summary>
    /// 상황별로 나누어 Fade 효과를 줌
    /// 상황1 : 스테이지 이동, 상황2 : 죽음, 상황3 : 스테이지 클리어
    /// </summary>
    /// <param name="_situation"></param>
    public void Fade(string _situation)
    {
        situation = _situation;
        //inventory.SetActive(false);

        switch(situation)
        {
            case "settingMap":
                StartCoroutine(FadeProcess(situation, FadeImages[0]));
                //inventory.SetActive(false);
                break;
            case "dead":
                StartCoroutine(FadeProcess(situation, FadeImages[1]));
                //inventory.SetActive(false);
                break;
            case "Clear":
                StartCoroutine(FadeProcess(situation, FadeImages[2]));
                //inventory.SetActive(false);
                break;

        }
    }

    IEnumerator FadeProcess(string _situation, Image _image)
    {
        inventory.SetActive(false);
        if (_situation == "dead")
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

        if(_situation == "settingMap")
        {
            PlayerController.Instance.transform.position = Vector3.zero;
            MapController.Instance.SetStage(PortalManager.currentPortal.portalCode);
        }
        if(_situation == "dead")
        {
            PlayerController.Instance.PlayerReplaced();
            deadCount.text = PlayerController.Instance.deathCount.ToString();
        }
        if(_situation == "Clear")
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
        inventory.SetActive(true);

        yield return null;
    }


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //stageInfo.text = "Lobby";
        deadCount.text = PlayerController.Instance.deathCount.ToString();
    }

    public void SetStageInfo(int _index)
    {
        _index++;
        stageInfo.text = "Stage " + _index.ToString();
    }

    public void ResetStageInfo()
    {
        stageInfo.text = "";
    }

    public void NoticeRequried()
    {
        Required.text = "A key is required to clear!";
    }

    public void ResetNoticeRequried()
    {
        Required.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
