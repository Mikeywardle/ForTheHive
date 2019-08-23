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
    [SerializeField] private Tilemap buildings;
    [SerializeField] private Tile baseSprite;

    void Start()
    {

        Vector3Int blockPosition;
        //int numberOfBlocks = groundBlocks.Length -1;

        for (int i=-1*worldWidth; i < worldWidth; i++){
            for(int j=0; j > -11; j--)
            {
                blockPosition = new Vector3Int(i, j, 0);
                ground.SetTile(blockPosition, groundBlocks[0]);
            }
        }

        PlaceBase();
    }

    public void PlaceBase()
    {
        buildings.SetTile(new Vector3Int(0, 1, 0), baseSprite);
        buildings.SetTile(new Vector3Int(1, 1, 0), baseSprite);
    }
}
