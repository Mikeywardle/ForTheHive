using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    private List<Building> buildings = new List<Building>();
    private int numOfPlaceables = 0;
    private int totalPopulation = 0;
    private int totalPower = 0;
    private int totalOre = 20;

    [SerializeField] private Text electricityText;
    [SerializeField] private Text populationText;
    [SerializeField] private Text oreText;

    private float deltaTime;
    private Placeable current;

    void Update()
    {
        deltaTime = Time.deltaTime;    

        foreach (Building building in buildings)
        {
            current = building.placeable;
            if (current.reqPower <= totalPower)
            {
                current.remainingResourceTime -= deltaTime;

                if (current.remainingResourceTime <= 0)
                {
                    totalOre += current.ore;
                    totalPower += (current.power-current.reqPower);
                    current.remainingResourceTime = current.totalResourceTime;
                }
            }
        }
        oreText.text = totalOre.ToString();
        electricityText.text = totalPower.ToString();
        populationText.text = totalPopulation.ToString();
    }

    public bool addPlaceable(Building building)
    {
        Placeable placeable = building.placeable;
        //if (CantAfford(placeable))
          //  return false;

        totalPopulation += placeable.population;
        totalOre -= placeable.reqOre;
        totalPopulation -= placeable.reqPopulation;
        buildings.Add(building);

        numOfPlaceables++;
        return true;
    }

    private bool CantAfford(Placeable placeable)
    {
        return placeable.reqOre > totalOre
            || placeable.reqPopulation > totalPopulation;
    }
}
