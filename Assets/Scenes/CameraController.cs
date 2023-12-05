using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{public float speed = 5.0f;
    public LayerMask groundLayer; // Set this in the inspector to the layer where your ground objects are.

    void Update()
    {
        // Get input from arrow keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(horizontal, 0.0f, vertical).normalized;

        // Move the camera
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // Perform raycast to check for ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            // Adjust the camera's y position to stay above the ground
            float yOffset = 0.5f; // Adjust this value based on your camera height
            transform.position = new Vector3(transform.position.x, hit.point.y + yOffset, transform.position.z);
        }
    }
}
