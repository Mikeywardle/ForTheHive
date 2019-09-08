using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSetter : MonoBehaviour
{
    [SerializeField] private Color blockedColor;
    [SerializeField] private Color placeColor;
    [SerializeField] private Color clear;

    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private Building buildingPrefab;

    private Building toPlace;

    private Vector3Int mousePositionInt;
    private Vector3 mousePosition;
    private Vector3Int drawPos;


    void Update()
    {

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePositionInt = new Vector3Int((int)mousePosition.x, (int)mousePosition.y, 0);

            if (toPlace && mousePositionInt.y > 0) {
                toPlace.GetComponent<SpriteRenderer>().color = Color.white;
                toPlace.gameObject.transform.position = new Vector3(mousePositionInt.x, mousePositionInt.y, 0);
            if (Input.GetMouseButtonDown(0) && UIUtils.mouseIsOverUI())
                Instantiate(toPlace.gameObject);
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
