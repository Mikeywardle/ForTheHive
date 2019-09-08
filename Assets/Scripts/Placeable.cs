﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
[CreateAssetMenu(fileName = "newBuilding", menuName = "ScriptableObject/Buildings")]
[System.Serializable]
public class Placeable : ScriptableObject
{
    public int population;
    public int ore;
    public int power;
    public float totalResourceTime;
    public float remainingResourceTime;

    public int reqOre;
    public int reqPopulation;
    public int reqPower;

    public Sprite sprite;
    
}
