using System;
using UnityEngine;

[Serializable] // Á÷·ÄÈ­
public class Data
{
    public bool[] isUnlock = new bool[3];
    public bool[] isSave = new bool[3];
    public Inventory playerInventory;
    public int deathCount;
    public Vector3 savePoint;
    public Vector3 deathPosition;

    private void Start()
    {
        
    }
}
