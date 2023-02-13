using System;
using UnityEngine;

[Serializable] // Á÷·ÄÈ­
public class Data
{
    public bool[] isUnlock = new bool[10];
    public int deathCount;
    public Vector3 savePoint;

    private void Start()
    {
        //savePoint = GetComponent<Transform>();
    }
}
