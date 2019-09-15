using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{
    private Dictionary<EconomicLevel, List<Person>> peopleMap = new Dictionary<EconomicLevel, List<Person>>();

    [SerializeField] GameObject personPrefab;

    private int totalPopulation; 
    void Start()
    {
        peopleMap.Add(EconomicLevel.WORKING_CLASS, new List<Person>());
        peopleMap.Add(EconomicLevel.MIDDLE_CLASS, new List<Person>());
        peopleMap.Add(EconomicLevel.NOBILITY, new List<Person>());

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

    public void addPeople(float numberOfPeople, EconomicLevel economicLevel)
    {
        for(int i = 0; i<numberOfPeople; i++)
        {
            peopleMap[economicLevel].Add(Instantiate(personPrefab).GetComponent<Person>());
        }
    }
}
