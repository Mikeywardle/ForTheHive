using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSetter : MonoBehaviour
{
    public Tilemap toPlaceMap;
    public Tilemap buildingMap;
    public Placeable toPlace;
    public Color blockedColor;
    public Color placeColor;

    private Vector3Int mousePositionInt;

    void Update()
    {
        toPlaceMap.ClearAllTiles();
        toPlaceMap.color = placeColor;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePositionInt = new Vector3Int((int)mousePosition.x, (int)mousePosition.y, 0);

        if (toPlace && mousePositionInt.y > 0) {
            bool canPlace =  DrawTiles(toPlaceMap);
            if (!canPlace)
                toPlaceMap.color = blockedColor;
            else if (Input.GetMouseButtonDown(0))
                DrawTiles(buildingMap);  

        }
    }
       
    private bool DrawTiles(Tilemap map)
    {
        int midpoint = (toPlace.width / 2) + 1;
        bool canPlace = true;
        for (int j = 0; j < toPlace.height; j++)        {
            for (int i = 0; i < toPlace.width; i++)
            {
                Vector3Int drawPos = new Vector3Int(0, mousePositionInt.y+j, 0);
                drawPos.x = mousePositionInt.x + (i - midpoint);
                map.SetTile(drawPos, toPlace.rows[0].tiles[i]);

                if (buildingMap.HasTile(drawPos))
                    canPlace = false;
            }
        }
        return canPlace;
    }
}
