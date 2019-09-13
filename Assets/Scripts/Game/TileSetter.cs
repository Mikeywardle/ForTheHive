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
    [SerializeField] private GameObject buildingPrefab;

    private GameObject toPlace;

    private Vector3Int mousePositionInt;
    private Vector3 mousePosition;
    private Vector3Int drawPos;
    private Collider2D[] collisions;
    private bool isAdjacent;
    private float offset;

    void Update()
    {
        if (toPlace)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePositionInt = new Vector3Int((int)mousePosition.x, (int)mousePosition.y, 0);
            collisions = Physics2D.OverlapAreaAll(toPlace.GetComponent<BoxCollider2D>().bounds.min, toPlace.GetComponent<BoxCollider2D>().bounds.max);

            if (mousePositionInt.y > 0)
            {
                toPlace.GetComponent<SpriteRenderer>().color = placeColor;
                toPlace.gameObject.transform.position = new Vector3(mousePositionInt.x+offset, mousePositionInt.y, 0);
                if (collisions.Length > 1 || NotAdjacent(toPlace.GetComponent<BoxCollider2D>()) || resourceManager.CantAfford(toPlace.GetComponent<Building>().placeable))
                {
                    toPlace.GetComponent<SpriteRenderer>().color = blockedColor;
                }
                else if (Input.GetMouseButtonDown(0) && UIUtils.mouseIsOverUI())
                {
                    toPlace.GetComponent<SpriteRenderer>().color = Color.white;
                    GameObject toAdd = Instantiate(toPlace);
                    resourceManager.addPlaceable(toAdd.GetComponent<Building>());
                }
            }
        }
    }

    private bool NotAdjacent(BoxCollider2D collider)
    {
        return collider.Cast(Vector2.right, new RaycastHit2D[2],1)==0 
            && collider.Cast(Vector2.left, new RaycastHit2D[2], 1) == 0
            && collider.Cast(Vector2.down, new RaycastHit2D[2], 1) == 0;
    }

    public void LoadToPlace(Placeable placeable)
    {
        Destroy(toPlace);
        toPlace = Instantiate(buildingPrefab);
        toPlace.transform.position = mousePositionInt;
        offset = toPlace.GetComponent<Building>().LoadBuiling(placeable);
    }

    public void ClearToPlace()
    {
        Destroy(toPlace);
        toPlace = null;
    }
}
