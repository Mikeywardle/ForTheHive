using System;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    private Dictionary<EconomicLevel, List<Building>> buildingsMap = new Dictionary<EconomicLevel, List<Building>>();

    private int numOfPlaceables = 0;
    private int totalPopulation = 0;
    private int unemployedPopulation = 0;
    private int totalPower = 0;
    private int remainingPower = 0;
    private int totalOre = 20;

    [SerializeField] private Text electricityText;
    [SerializeField] private Text populationText;
    [SerializeField] private Text oreText;

    private float deltaTime;
    private Placeable currentPopulating;
    private Placeable currentProcessing;
    private Queue<Building> toProcess = new Queue<Building>();
    private bool processing;
    private bool populating;

    private Thread thread1;
    private Thread thread2;
    private Thread thread3;

    void Start()
    {
        thread1 = new Thread(processOutput);
        thread1.Start();
        thread2 = new Thread(processOutput);
        thread2.Start();
        thread3 = new Thread(processOutput);
        thread3.Start();

        buildingsMap.Add(EconomicLevel.WORKING_CLASS, new List<Building>());
        buildingsMap.Add(EconomicLevel.MIDDLE_CLASS, new List<Building>());
        buildingsMap.Add(EconomicLevel.NOBILITY, new List<Building>());
    }

    void Update()
    {
       deltaTime = Time.deltaTime;
        remainingPower = totalPower;
        unemployedPopulation = totalPopulation;

        //thread1.Join();
        //thread2.Join();

        foreach (List<Building> buildings in buildingsMap.Values)
        {
            foreach (Building building in buildings)
            {
                currentPopulating = building.placeable;

                switch (currentPopulating.generationType)
                {
                    case GenerationType.RECURRING:
                        if (currentPopulating.reqPower <= remainingPower)
                        {
                            currentPopulating.remainingResourceTime -= deltaTime;
                            remainingPower -= currentPopulating.reqPower;

                            if (currentPopulating.remainingResourceTime <= 0)
                            {
                                totalOre += currentPopulating.ore;
                                currentPopulating.remainingResourceTime = currentPopulating.totalResourceTime;
                            }
                        }
                        break;
                }

            }
        }

        oreText.text = totalOre.ToString();
        electricityText.text = totalPower.ToString();
        populationText.text = totalPopulation.ToString();
    }

    public void addPlaceable(Building building)
    {
        Placeable placeable = building.placeable;

        totalPopulation += placeable.population;
        totalPower += placeable.power;
        totalOre -= placeable.reqOre;
        totalPopulation -= placeable.reqPopulation;
        buildingsMap[placeable.economicLevel].Add(building);

        numOfPlaceables++;
    }

    public bool CantAfford(Placeable placeable)
    {
        return placeable.reqOre > totalOre;
    }

        

    private void processOutput()
    {
        processing = true;
        Building building;


        while (processing)
        {
            if (toProcess.Count>0)
            {
                building = toProcess.Dequeue();
                currentProcessing = building.placeable;
                totalOre += currentProcessing.ore;
                totalPower += (currentProcessing.power - currentProcessing.reqPower);
                currentProcessing.remainingResourceTime = currentProcessing.totalResourceTime;
            } else if (!populating)
            {
                processing = false;
            }
        }
    }
}
