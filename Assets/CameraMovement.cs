using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instance;
    public Transform target;  // Player's transform for following
    public float smoothSpeed = 0.125f;  // Smoothing factor for camera movement
    public Vector2 parallaxEffectMultiplier;  // Parallax effect intensity (x, y)
    private Vector3 lastCameraPosition;  // Tracks the camera's last position

    public float minX = -5.5f;  // Minimum X bound
    public float maxX = 5.5f;   // Maximum X bound

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (target == null)
        {
            // Find the player if target is not assigned
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                target = player.transform;  // Assign the player's transform
                Debug.Log("Player found by Camera.");
            }
        }

        lastCameraPosition = transform.position;  // Initialize last camera position
    }

   private void LateUpdate()
    {
        if (target == null) return;

        // Step 1: Camera follow on X axis (horizontal movement only)
        Vector3 desiredPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
        
        // Smooth the movement towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Step 2: Clamp the camera's X position to stay within bounds
        smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minX, maxX);

        // Apply the clamped position
        transform.position = smoothedPosition;

        // Optional: Handle Parallax for background (if you plan to implement this part later)
    }

}
