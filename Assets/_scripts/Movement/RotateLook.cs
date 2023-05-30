using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLook : PlayerMovementInitialise
{
    [SerializeField] private float _lookSensitivity = 10;
    public GameObject CameraLookFocus;

    private float rotationX = 0f;
    private float rotationY = 0f;

    private void FixedUpdate()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        float lookX = _handlePlayerInput.RightStickAxis.x * _lookSensitivity * Time.deltaTime;
        float lookY = _handlePlayerInput.RightStickAxis.y * _lookSensitivity * Time.deltaTime;

        rotationY += lookX;
        rotationX -= lookY;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        CameraLookFocus.transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }
}
