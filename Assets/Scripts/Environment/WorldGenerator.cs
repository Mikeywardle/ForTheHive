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
    [SerializeField] private Tilemap groundBack;
    [SerializeField] private Placeable baseShip;
    [SerializeField] private GameObject buildingPrefab;
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private float amplitude;
    [SerializeField] private float phase;

    void Start()
    {

        Vector3Int blockPosition;
        int height;
        float perlin=0;

        for (int i=-1*worldWidth; i < worldWidth; i++){

            if (i <= 10 && i >= -10)
                height = 0;
            else
                perlin= Mathf.PerlinNoise(i / 0.0001f, amplitude / 0.0001f);
                //Debug.Log(perlin);
                height = Mathf.FloorToInt(perlin);


            for (int j=0; j > -20; j--)
            {
                blockPosition = new Vector3Int(i, j, 0);
                ground.SetTile(blockPosition, groundBlocks[0]);

            }
            for (int j = 0; j > -20; j--)
            {
                blockPosition = new Vector3Int(i, j, 0);

                groundBack.SetTile(blockPosition, groundBlocks[0]);
            }
        }

        GameObject origin = Instantiate(buildingPrefab);
        origin.GetComponent<Building>().LoadBuiling(baseShip);
        origin.transform.position = new Vector3(0.5f, 1, 0);
        resourceManager.addPlaceable(origin.GetComponent<Building>());
    }
}
