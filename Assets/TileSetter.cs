using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSetter : MonoBehaviour
{

    public Tilemap buildingMap;
    public Tile toPlace;
    // Start is called before the first frame update
    void Start()
    {
        buildingMap.SetTile(new Vector3Int(1, 1, 0), toPlace);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
