using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Used,
    }

    public string itemName; //아이템의 이름
    public ItemType itemType; //아이템 유형
    public Sprite itemImage; //아이템의 이미지(인벤토리 안에서 띄울)
    public GameObject itemPrefab; //아이템의 프리팹 (아이템 생성 시 프리팹으로 찍어냄)
}
