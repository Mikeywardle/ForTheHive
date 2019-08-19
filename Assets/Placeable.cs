using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class TileRow
{
    public Tile[] tiles;
}

public class Placeable : MonoBehaviour
{
    public TileRow[] rows;
    public int height;
    public int width;

    public void Start()
    {
        height = rows.Length;
        width = rows[0].tiles.Length;
    }

}
