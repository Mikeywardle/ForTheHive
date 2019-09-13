using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceTester : MonoBehaviour
{

    [SerializeField] private GameObject buildingPrefab;
    [SerializeField] private Placeable testPlaceable;
    [SerializeField] private int load;
    [SerializeField] private ResourceManager resourceManager;

    private int column =1;
    private GameObject next;
    void Start()
    {
        
      for(int i=0; i<load; i++)
        {
            next = Instantiate(buildingPrefab,new Vector3(column+2, (i/10)+1,0), Quaternion.identity);
            next.GetComponent<Building>().LoadBuiling(testPlaceable);
            resourceManager.addPlaceable(next.GetComponent<Building>());
            column++;
            if (column == 10)
                column = 0;
        }  
    }

    void Update()
    {
        
    }
}
