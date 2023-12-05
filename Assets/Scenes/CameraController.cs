using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float speed = 5.0f;
    public float rotationSpeed = 2.0f;

    void Update()
    {
        // Move the camera based on arrow keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0.0f, vertical).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // Rotate the camera based on mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * rotationSpeed);

        // Perform raycast to check for ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            float yOffset = 0.5f;
            transform.position = new Vector3(transform.position.x, hit.point.y + yOffset, transform.position.z);
        }
    }
}
