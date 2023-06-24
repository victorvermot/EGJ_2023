using UnityEngine;
using System;

public class PlayerMovementController : MonoBehaviour
{
    private Camera mainCamera;
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        HandleMouseRotation();
        HandleMovement();
    }

    private void HandleMovement(){
        float horizontalInput = Input.GetAxis("Horizontal");
        // float horizontalInput = Math.Sign(Input.GetAxis("Horizontal"));
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput,verticalInput, 0);
        movement = movement.normalized * moveSpeed * Time.deltaTime;
        // Apply movement
        transform.position += movement;
    }

    private void HandleMouseRotation(){
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to world coordinates
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z - mainCamera.transform.position.z));

        // Calculate the direction from the character position to the mouse position
        Vector3 directionToMouse = mouseWorldPosition - transform.position;

        // Rotate the character to face the mouse position
        transform.up = directionToMouse.normalized;
    }
    
}
