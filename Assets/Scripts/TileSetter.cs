using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSetter : MonoBehaviour
{
    [SerializeField] private Color blockedColor;
    [SerializeField] private Color placeColor;

    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private Building buildingPrefab;

    private Building toPlace;

    private Vector3Int mousePositionInt;
    private Vector3 mousePosition;
    private Vector3Int drawPos;
    private bool collision;
    private bool isAdjacent;


    void Update()
    {
        if (toPlace)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePositionInt = new Vector3Int((int)mousePosition.x, (int)mousePosition.y, 0);
            collision = Physics2D.IsTouchingLayers(toPlace.GetComponent<BoxCollider2D>(),Physics2D.AllLayers);
            if (mousePositionInt.y > 0)
            {
                toPlace.GetComponent<SpriteRenderer>().color = placeColor;
                toPlace.gameObject.transform.position = new Vector3(mousePositionInt.x, mousePositionInt.y, 0);
                if (collision)
                    toPlace.GetComponent<SpriteRenderer>().color = blockedColor;
                else if (Input.GetMouseButtonDown(0) && UIUtils.mouseIsOverUI())
                {
                    toPlace.GetComponent<SpriteRenderer>().color = Color.white;
                    Building toAdd = Instantiate(toPlace);
                    resourceManager.addPlaceable(toAdd);
                }
            }
        }
    }

    //private bool Adjacent(Vector3Int currentTile)
    //{
    //    Vector3Int xPlus = currentTile;
    //    Vector3Int xMinus = currentTile;
    //    Vector3Int yMinus = currentTile;

    //    xPlus.x += 1;
    //    xMinus.x -= 1;
    //    yMinus.y -= 1;
    //}

    public void LoadToPlace(Placeable placeable)
    {
        toPlace = Instantiate(buildingPrefab);
        toPlace.LoadBuiling(placeable);
    }

    public void ClearToPlace()
    {
        toPlace = null;
    }
}
