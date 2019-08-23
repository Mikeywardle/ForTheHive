using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    private Dictionary<Vector2Int, Placeable> placeables = new Dictionary<Vector2Int, Placeable>();
    private int numOfPlaceables = 0;
    private int totalPopulation = 0;
    private int totalPower = 0;
    private int totalOre = 20;

    [SerializeField] private Text electricityText;
    [SerializeField] private Text populationText;
    [SerializeField] private Text oreText;

    private Placeable current;
    private float deltaTime;

    void Update()
    {
        deltaTime = Time.deltaTime;    

        foreach (KeyValuePair<Vector2Int, Placeable> entry in placeables)
        {
            current = entry.Value;
            if (current.generatesResources)
            {
                current.remainingResourceTime -= deltaTime;

                if (current.remainingResourceTime <= 0)
                {
                    totalOre += current.ore;
                    totalPower += current.power;
                    current.remainingResourceTime = current.totalResourceTime;
                }
            }
        }
        oreText.text = totalOre.ToString();
        electricityText.text = totalPower.ToString();
        populationText.text = totalPopulation.ToString();
    }

    public bool addPlaceable(Placeable placeable)
    {
        if (CantAfford(placeable))
            return false;

        totalPopulation += placeable.population;
        totalOre -= placeable.reqOre;
        totalPopulation -= placeable.reqPopulation;
        placeables.Add(placeable.position, placeable);

        numOfPlaceables++;
        return true;
    }

    private bool CantAfford(Placeable placeable)
    {
        return placeable.reqOre > totalOre
            || placeable.reqPopulation > totalPopulation;
    }
}
