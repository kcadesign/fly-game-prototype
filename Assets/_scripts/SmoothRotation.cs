using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotation : MonoBehaviour
{
    public float smoothSpeed = 0.125f; // The smoothing factor for camera rotation

    void LateUpdate()
    {
        // Calculate the desired rotation of the camera based on the target's rotation
        Quaternion currentRotation = transform.rotation;

        // Smoothly rotate the camera towards the desired rotation
        Quaternion smoothedRotation = Quaternion.Lerp(currentRotation, transform.rotation, smoothSpeed);

        // Update the camera rotation
        transform.rotation = smoothedRotation;
    }
}
