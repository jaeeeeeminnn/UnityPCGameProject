using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    static GameObject container;

    //싱글톤으로 선언
    private static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if(!instance)
            {
                container = new GameObject();
                container.name = "DataManager";
                instance = container.AddComponent(typeof(DataManager)) as DataManager;
                DontDestroyOnLoad(container);
            }
            return instance;
        }
    }
    public static bool isLoadingData = false;
    //게임 데이터 파일이름 설정
    string GameDataFileName = "GameData.json";
    //저장용 클래스 변수
    public Data data = new Data();

    /// <summary>
    /// 데이터 불러오는 함수
    /// </summary>
    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;

        if(File.Exists(filePath))
        {
            string FromJsonData = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<Data>(FromJsonData);
            isLoadingData = true;
            Debug.Log("불러오기 완료");
        }
    }
    
    /// <summary>
    /// 데이터 저장하는 함수
    /// </summary>
    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(data, true);
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;

        File.WriteAllText(filePath, ToJsonData);

        Debug.Log("저장 완료");
        for(int i=0;i<data.isUnlock.Length;i++)
        {
            Debug.Log(i+"번 챕터 잠금 해제 여부 : " + data.isUnlock[i]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
