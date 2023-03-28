using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    static GameObject container;

    //�̱������� ����
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
    //���� ������ �����̸� ����
    string GameDataFileName = "GameData.json";
    //����� Ŭ���� ����
    public Data data = new Data();

    /// <summary>
    /// ������ �ҷ����� �Լ�
    /// </summary>
    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;

        if(File.Exists(filePath))
        {
            string FromJsonData = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<Data>(FromJsonData);
            isLoadingData = true;
            Debug.Log("�ҷ����� �Ϸ�");
        }
    }
    
    /// <summary>
    /// ������ �����ϴ� �Լ�
    /// </summary>
    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(data, true);
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;

        File.WriteAllText(filePath, ToJsonData);

        Debug.Log("���� �Ϸ�");
        for(int i=0;i<data.isUnlock.Length;i++)
        {
            Debug.Log(i+"�� é�� ��� ���� ���� : " + data.isUnlock[i]);
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
