using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSurfaceStick : PlayerMovementInitialise
{
    public Transform CameraRotation;
    public GameObject LandingPrompt;

    private int _numberOfRayHits = 0;
    private Vector3 _averageNormal = Vector3.zero;

    public float StickingForce = 15;
    public int NumberOfRays = 6;
    public float MaxRayDistance = 1f;
    public float RaycastAngle = 360f;

    public bool Sticking = false;

    private bool _previousButtonState = false;

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        SetRaycastAngle();
        HandleStickingLogic();
        AddForceAgainstNormal();
        HandleLandingPrompt();
    }

    private void HandleStickingLogic()
    {
        bool currentButtonState = _handlePlayerInput.ButtonSouthPressed;

        if (_numberOfRayHits == 0)
        {
            Sticking = false;
        }
        else if (_numberOfRayHits > 0 && currentButtonState && !_previousButtonState)
        {
            // Button was just pressed, update the sticking state
            Sticking = !Sticking;
            print("Sticking: " + Sticking);
        }

        // Update the previous button state
        _previousButtonState = currentButtonState;
    }

    private void SetRaycastAngle()
    {
        _numberOfRayHits = 0;

        for (int i = 0; i < NumberOfRays; i++)
        {
            // Set raycast direction
            Vector3 rayDirectionRight = Quaternion.AngleAxis(i * RaycastAngle / (NumberOfRays - 1) - RaycastAngle / 2, transform.right) * -transform.up;
            Vector3 rayDirectionForward = Quaternion.AngleAxis(i * RaycastAngle / (NumberOfRays - 1) - RaycastAngle / 2, transform.forward) * -transform.up;

            CalculateAverageNormal(rayDirectionRight, rayDirectionForward);
        }
    }

    private void CalculateAverageNormal(Vector3 rayDirectionRight, Vector3 rayDirectionForward)
    {
        // Calculate raycast hit average normal
        if (Physics.Raycast(transform.position, rayDirectionRight, out RaycastHit hitRight, MaxRayDistance))
        {
            Debug.DrawLine(transform.position, hitRight.point, Color.red);
            _averageNormal += hitRight.normal;
            _numberOfRayHits++;
        }

        if (Physics.Raycast(transform.position, rayDirectionForward, out RaycastHit hitForward, MaxRayDistance))
        {
            Debug.DrawLine(transform.position, hitForward.point, Color.green);
            _averageNormal += hitForward.normal;
            _numberOfRayHits++;
        }
    }

    private void AddForceAgainstNormal()
    {
        if (!Sticking)
        {
            return;
        }
        else
        {
            rigidBody.velocity = Vector3.zero;
            _averageNormal /= _numberOfRayHits;
            rigidBody.AddForce(-_averageNormal * StickingForce, ForceMode.Impulse);
            transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.right, _averageNormal), _averageNormal);
        }
    }

    private void HandleLandingPrompt()
    {
        if(_numberOfRayHits == 0)
        {
            LandingPrompt.SetActive(false);
        }
        else if(_numberOfRayHits > 0)
        {
            LandingPrompt.SetActive(true);
        }
    }

}



