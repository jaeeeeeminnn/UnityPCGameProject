using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyArea : MonoBehaviour
{
    public static LobbyArea currentLobbyArea; // �÷��̾ �ֱٿ� ���� LobbyArea
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
