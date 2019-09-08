using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Vector2Int position;
    public Placeable placeable { get; private set; }
    public bool overlap { get; private set; }


    public void LoadBuiling(Placeable placeable)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.placeable = placeable;
        spriteRenderer.sprite = this.placeable.sprite;
    }
}
