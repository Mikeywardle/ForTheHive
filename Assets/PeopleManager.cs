using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{
    private Dictionary<EconomicLevel, List<Person>> peopleMap = new Dictionary<EconomicLevel, List<Person>>();

    private int totalPopulation; 
    void Start()
    {
        
    }
       
    // Update is called once per frame
    void Update()
    {
        foreach(List<Person> people in peopleMap.Values)
        {
            foreach(Person person in people)
            {
                person.gameObject.transform.Translate(Vector3.right);
            }
        }
        
    }
}
