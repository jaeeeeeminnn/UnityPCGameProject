using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPool : MonoBehaviour
{
    private static DataPool instance;
    public static DataPool Instance
    {
        get
        {
            return instance;
        }
    }

    public static int itemCount = 1;
    public static List<Item> items = new List<Item>();
    public static int itemPrefabCount = 2;
    public static List<GameObject> itemPrefabs = new List<GameObject>();
    public static GameObject[] itemPrefab;

    private void Awake()
    {
        instance = this;

        for(int i= 0; i < itemCount; i++)
        {
            items.Add(new Item(i));
        }

        if(itemPrefab == null)
        {
            itemPrefab = Resources.LoadAll<GameObject>("Prefab");
        }

        for(int i=0;i<itemPrefabCount;i++)
        {
            itemPrefabs.Add(itemPrefab[i]);
        }
        Debug.Log(itemPrefabs.Count);

    }

    public Item SearchItem(int _itemCode)
    {
        return items[_itemCode];
    }

}
