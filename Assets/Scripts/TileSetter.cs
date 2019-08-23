using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSetter : MonoBehaviour
{
    [SerializeField] private Color blockedColor;
    [SerializeField] private Color placeColor;

    [SerializeField] private Tilemap toPlaceMap;
    [SerializeField] private Tilemap buildingMap;

    [SerializeField] private ResourceManager resourceManager;

    private Placeable toPlace;

    private Vector3Int mousePositionInt;
    private Vector3 mousePosition;
    private Vector3Int drawPos;

    private int placeableHeight;
    private int placeableWidth;

    void Update()
    {
        toPlaceMap.ClearAllTiles();

        //if () { 
            toPlaceMap.color = placeColor;
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePositionInt = new Vector3Int((int)mousePosition.x, (int)mousePosition.y, 0);

            if (toPlace && mousePositionInt.y > 0) {
                bool canPlace =  DrawTiles(toPlaceMap);
                if (!canPlace)
                    toPlaceMap.color = blockedColor;
                else if (Input.GetMouseButtonDown(0)&& UIUtils.mouseIsOverUI())
                    AddPlaceable();
            }
        //}
    }

    private void AddPlaceable()
    {
        Placeable toAdd = Instantiate(toPlace);
        toAdd.position = new Vector2Int(mousePositionInt.x, mousePositionInt.y);
        if (resourceManager.addPlaceable(toAdd))
            DrawTiles(buildingMap);
        else
            Destroy(toAdd);
    }

    private bool DrawTiles(Tilemap map)
    {
        int midpoint = (placeableWidth / 2) + 1;
        bool doesntOverlap = true;
        bool isAdjacent = false;
        for (int j = 0; j < placeableHeight; j++)        {
            for (int i = 0; i < placeableWidth; i++)
            {
                drawPos= new Vector3Int(0, mousePositionInt.y+j, 0);
                drawPos.x = mousePositionInt.x + (i - midpoint);
                map.SetTile(drawPos, toPlace.rows[0].tiles[i]);

                if (buildingMap.HasTile(drawPos))
                    doesntOverlap = false;
                isAdjacent = isAdjacent || Adjacent(drawPos);
            }
        }
        return doesntOverlap && isAdjacent;
    }

    private bool Adjacent(Vector3Int currentTile)
    {
        Vector3Int xPlus = currentTile;
        Vector3Int xMinus = currentTile;
        Vector3Int yMinus = currentTile;

        xPlus.x += 1;
        xMinus.x -= 1;
        yMinus.y -= 1;

        return buildingMap.HasTile(xMinus) || buildingMap.HasTile(xPlus) || buildingMap.HasTile(yMinus);
    }

    public void LoadToPlace(Placeable placeable)
    {
        toPlace = placeable;
        placeableHeight = toPlace.rows.Length;
        placeableWidth = toPlace.rows[0].tiles.Length;
        toPlace.remainingResourceTime = toPlace.totalResourceTime;
    }

    public void ClearToPlace()
    {
        toPlace = null;
    }
}
