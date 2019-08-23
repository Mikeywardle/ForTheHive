using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Designed to create an instance of The Game Data during Unity Editor runs if the game Data does not already exist
 * This is needed because the data is created in the main Menu when a new Game is started/loaded
 * This Should not run outside of the editor and should do nothing if the GameData is already created in another scene 
  */
public class DevDefaultDataCreator : MonoBehaviour
{
    [SerializeField] private GameObject gameDataPrefab;
    private void Awake(){
        #if UNITY_EDITOR
            if (GameObject.FindGameObjectWithTag("GameData")==null)
                Instantiate(gameDataPrefab);
        #endif
    }
}
