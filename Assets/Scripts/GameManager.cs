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

    public QuickSlotController quickSlot; //Player Inventory

    public static bool isLobby;
    public GameObject lobby;
    public GameObject[] Stages;
    public PlayerController player;
    public Tilemap portalTile;
    public Tile[] portalTiles;
    private Vector3Int[] portalPos = { new Vector3Int(14, -1, 0), new Vector3Int(24,2,0), new Vector3Int(36, 6,0)};
    private Vector3Int[] lobbyRespawnPos = { new Vector3Int(0,0,0), new Vector3Int(14,0,0), new Vector3Int(25,3,0), new Vector3Int(36,7,0)};

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
            instance = this;
        DataManager.Instance.LoadGameData(); //테스트 코드
        CreatePortal();
        PlayerZeroPosition();
        isLobby = true;
        UIController.Instance.ResetStageInfo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClearStage()
    {
        //수정해야함
        //Change Stage
        if(stageIndex < Stages.Length-1)
        {
            Stages[stageIndex].SetActive(false);
            stageIndex++;
            lobby.SetActive(true);
            isLobby = true;
            //Stages[stageIndex].SetActive(true);
            UIController.Instance.Fade("Clear");
            DataManager.Instance.data.isUnlock[stageIndex] = true;
            CreatePortal();
            PlayerZeroPosition();
            UIController.Instance.ResetStageInfo();
            quickSlot.RemoveAllItem();
            DataManager.Instance.SaveGameData();
        }
        else
        {
            Time.timeScale = 0.0f;
            Debug.Log("게임 클리어!");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            player.OnDie();
            Debug.Log("추락 감지됨");
        }
    }

    void PlayerZeroPosition()
    {
        player.transform.position = new Vector3(0, 0, -1);
        player.VelocityZero();
    }
    
    /// <summary>
    /// 포탈 생성 함수
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
        if(isLobby == true)
        {
            switch(LobbyArea.currentLobbyArea.areaCode)
            {
                case 0:
                    player.transform.position = lobbyRespawnPos[0];
                    break;
                case 1:
                    player.transform.position = lobbyRespawnPos[1];
                    break;
                case 2:
                    player.transform.position = lobbyRespawnPos[2];
                    break;

            }
            //player.transform.position = PlayerController.Instance.deathPosition - new Vector3(2,0,0); //자세한 작업 필요
        }
        else if(DataManager.Instance.data.isSave[stageIndex] == true && DataManager.Instance.data.savePoint != null)
        {
            player.transform.position = DataManager.Instance.data.savePoint;
        }
        else
        {
            PlayerZeroPosition();
        }
    }
 }


