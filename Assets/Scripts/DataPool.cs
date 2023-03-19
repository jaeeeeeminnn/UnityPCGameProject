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

    private void Awake()
    {
        instance = this;

        for(int i= 0; i < itemCount; i++)
        {
            items.Add(new Item(i));
        }
    }

}
