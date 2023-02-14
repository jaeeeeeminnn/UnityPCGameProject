using System;
using UnityEngine;

[Serializable] // Á÷·ÄÈ­
public class Data
{
    public bool[] isUnlock = new bool[10];
    public bool[] isSavePoint = new bool[10];
    public Inventory playerInventory;
    public int deathCount;
    public Vector3 savePoint;

    private void Start()
    {
        
    }
}
