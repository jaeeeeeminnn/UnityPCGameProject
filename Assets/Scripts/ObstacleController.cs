using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObstacleController : MonoBehaviour
{
    public Tilemap map;
    //public TileBase tilebase;

    // Start is called before the first frame update
    void Start()
    {
        map.GetTile(new Vector3Int(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
