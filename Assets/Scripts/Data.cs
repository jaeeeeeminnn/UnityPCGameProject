using System;

[Serializable] // ����ȭ
public class Data
{
    public bool[] isUnlock = new bool[10];
    //public int deathCount;
    //Transform savePoint;

    private void Start()
    {
        //savePoint = GetComponent<Transform>();
    }
}
