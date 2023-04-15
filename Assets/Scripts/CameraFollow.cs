using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public Vector3 offset; // Offset from the player object

    void LateUpdate()
    {
        // Set the position of the camera target object to the player's position with the offset added
        transform.position = player.position + offset;

        // Get the player's rotation on the x-axis
        float xRotation = player.eulerAngles.x;

        // Get the player's rotation on the y-axis
        float yRotation = player.eulerAngles.y;


        // Set the camera's rotation to match the player's rotation on the z-axis
        transform.eulerAngles = new Vector3(xRotation, yRotation, transform.eulerAngles.z);
    }
}
