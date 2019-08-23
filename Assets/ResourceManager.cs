using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    private Dictionary<Vector2Int, Placeable> placeables = new Dictionary<Vector2Int, Placeable>();
    private int numOfPlaceables = 0;
    private int totalPopulation = 0;
    private int totalElectricity = 0;
    private int totalOre = 0;

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
                    totalElectricity += current.electricity;
                    current.remainingResourceTime = current.totalResourceTime;
                }
            }
        }
        oreText.text = totalOre.ToString();
        electricityText.text = totalElectricity.ToString();
        populationText.text = totalPopulation.ToString();
    }

    public void addPlaceable(Placeable placeable)
    {
        totalPopulation += placeable.population;
        placeables.Add(placeable.position, placeable);
        numOfPlaceables++;
    }
}
