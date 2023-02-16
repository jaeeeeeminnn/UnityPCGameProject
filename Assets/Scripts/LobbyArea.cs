using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyArea : MonoBehaviour
{
    public static LobbyArea currentLobbyArea; // 플레이어가 최근에 접한 LobbyArea
    public int areaCode;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(areaCode);
            currentLobbyArea = this;
        }
    }

    
}
