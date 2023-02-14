using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public int stageIndex; //StageCode

    public Inventory theinventory; //Player Inventory

    public GameObject stageMap;
    public GameObject[] Stages;
    public PlayerController player;
    public Tilemap portalTile;
    public Tile[] portalTiles;
    private Vector3Int[] portalPos = { new Vector3Int(14, -1, 0), new Vector3Int(25,2,0), new Vector3Int(36, 6,0)};

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
            instance = this;
        DataManager.Instance.LoadGameData();
        CreatePortal();
        PlayerZeroPosition();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClearStage()
    {
        //�����ؾ���
        //Change Stage
        if(stageIndex < Stages.Length-1)
        {
            Stages[stageIndex].SetActive(false);
            stageIndex++;
            stageMap.SetActive(true);
            //Stages[stageIndex].SetActive(true);
            UIController.Instance.Fade("Clear");
            DataManager.Instance.data.isUnlock[stageIndex] = true;
            CreatePortal();
            PlayerZeroPosition();
            UIController.Instance.ResetStageInfo();
            theinventory.RemoveAllItem();
            DataManager.Instance.SaveGameData();
        }
        else
        {
            Time.timeScale = 0.0f;
            Debug.Log("���� Ŭ����!");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            player.OnDie();
            Debug.Log("�߶� ������");
        }
    }

    void PlayerZeroPosition()
    {
        player.transform.position = new Vector3(0, 0, -1);
        player.VelocityZero();
    }
    
    /// <summary>
    /// ��Ż ���� �Լ�
    /// </summary>
    void CreatePortal()
    {
        for (int i = 0; i < DataManager.Instance.data.isUnlock.Length; i++)
        {
            if (DataManager.Instance.data.isUnlock[i] == true)
            {
                portalTile.SetTile(portalPos[i], portalTiles[0]);
            }
            else
            {
                portalTile.SetTile(portalPos[i], portalTiles[1]);
            }
        }
    }

    public void DiePlayerReplace()
    {
        if(DataManager.Instance.data.isSave[stageIndex] == true && DataManager.Instance.data.savePoint != null)
        {
            player.transform.position = DataManager.Instance.data.savePoint;
        }
        else
        {
            PlayerZeroPosition();
        }
    }
 }


