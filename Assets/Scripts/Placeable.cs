using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class TileRow
{
    public Tile[] tiles;
}

[CreateAssetMenu(fileName = "newBuilding", menuName = "Prefabs/Buildings")]
[System.Serializable]
public class Placeable : ScriptableObject
{
    public bool generatesResources;

    public int population;
    public int ore;
    public int power;
    public float totalResourceTime;
    public float remainingResourceTime;

    public int reqOre;
    public int reqPopulation;
    public int reqPower;

    public TileRow[] rows;
    public Vector2Int position;   

}
