using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;
    [SerializeField] private float verticalParallaxRatio;

    private Vector3 originalPosition;
    private Vector3 cameraPosition;
    private Vector3 newPosition;

    void Start()
    {
        originalPosition = gameObject.transform.localPosition;
    }

    void Update()
    {
        cameraPosition = mainCamera.transform.position;
        newPosition = originalPosition;
        newPosition.y += cameraPosition.y * verticalParallaxRatio;
        gameObject.transform.localPosition = newPosition;
        
    }
}
