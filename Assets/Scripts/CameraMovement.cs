using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private CharacterController controller;
    [SerializeField] private float movementSpeed;

    private Vector3 frameMove;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        frameMove = Input.GetAxis("Horizontal") * Vector3.right * Time.deltaTime * movementSpeed;
        frameMove += Input.GetAxis("Vertical") * Vector3.up * Time.deltaTime * movementSpeed;

        controller.Move(frameMove);
    }
}
