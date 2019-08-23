using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour
{
    private TileSetter tileSetter;
    private Button button;
    [SerializeField] private Placeable placeable;

    void Start()
    {
        tileSetter = GameObject.Find("BuildingPlacer").GetComponent<TileSetter>();
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadToPlace);
    }

    private void LoadToPlace()
    {
        tileSetter.LoadToPlace(placeable) ;
    }
}
