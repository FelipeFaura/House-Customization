using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform playerBody;

    private bool isMoving = true;
    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        // Disable the cursor on screen
        Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
        // Input Data
        if (isMoving) {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90);
            // Actual rotation of the camera.
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            // Rotation of the character
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }

    public void StopMovement() {
        isMoving = false;
    }

    public void StartMovement() {
        isMoving = true;
    }
}
