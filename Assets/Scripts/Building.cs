using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Vector2Int position;
    public Placeable placeable { get; private set; }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void LoadBuiling(Placeable placeable)
    {
        this.placeable = placeable;
        spriteRenderer.sprite = this.placeable.sprite;
    }

}
