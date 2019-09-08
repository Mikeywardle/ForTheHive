using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] private Tile[] groundBlocks;
    [SerializeField] private int worldWidth;
    [SerializeField] private Tilemap ground;
    [SerializeField] private Placeable baseShip;

    void Start()
    {

        Vector3Int blockPosition;

        for (int i=-1*worldWidth; i < worldWidth; i++){
            for(int j=0; j > -11; j--)
            {
                blockPosition = new Vector3Int(i, j, 0);
                ground.SetTile(blockPosition, groundBlocks[0]);
            }
        }

    }

}
