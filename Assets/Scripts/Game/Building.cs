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
        this.placeable = placeable;

        spriteRenderer = GetComponent<SpriteRenderer>();
        employees = new Person[placeable.reqPopulation];

        spriteRenderer.sprite = placeable.sprite;
        Rect rect = GetComponent<SpriteRenderer>().sprite.rect;
        float resolution = GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        GetComponent<BoxCollider2D>().size = new Vector2((rect.width / resolution) - 0.1f, (rect.height / resolution)-0.1f);

        if ((rect.width / resolution) % 2 == 0)
            return 0.5f;
        return 0;
    }
}
