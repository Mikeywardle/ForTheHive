using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Placeable placeable;
    public Person[] employees;

    public float LoadBuiling(Placeable placeable)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.placeable = placeable;
        employees = new Person[placeable.reqPopulation];

        spriteRenderer.sprite = this.placeable.sprite;
        Rect rect = GetComponent<SpriteRenderer>().sprite.rect;
        float resolution = GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        GetComponent<BoxCollider2D>().size = new Vector2((rect.width / resolution) - 0.1f, (rect.height / resolution));

        if ((rect.width / resolution) % 2 == 0)
            return 0.5f;
        return 0;
    }
}
