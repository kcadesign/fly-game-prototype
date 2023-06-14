using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandleSurfaceStick : PlayerMovementInitialise
{
    public GameObject StickPrompt;
    public GameObject HeadingArrow;

    private int _numberOfRayHits = 0;
    private Vector3 _averageNormal = Vector3.zero;

    public float StickingForce = 15;

    private int _numberOfRays = 24;
    private float _maxRayDistance = 1f;
    private float _raycastAngle = 360f;

    private bool _previousButtonState = false;

    public bool Sticking = false;

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

        for (int i = 0; i < _numberOfRays; i++)
        {
            // Set raycast direction
            Vector3 rayDirectionRight = Quaternion.AngleAxis(i * _raycastAngle / (_numberOfRays - 1) - _raycastAngle / 2, transform.right) * -transform.up;
            Vector3 rayDirectionForward = Quaternion.AngleAxis(i * _raycastAngle / (_numberOfRays - 1) - _raycastAngle / 2, transform.forward) * -transform.up;

            CalculateAverageNormal(rayDirectionRight, rayDirectionForward);
        }
    }

    private void CalculateAverageNormal(Vector3 rayDirectionRight, Vector3 rayDirectionForward)
    {
        // Calculate raycast hit average normal
        if (Physics.Raycast(transform.position, rayDirectionRight, out RaycastHit hitRight, _maxRayDistance))
        {
            Debug.DrawLine(transform.position, hitRight.point, Color.red);
            _averageNormal += hitRight.normal;
            _numberOfRayHits++;
        }

        if (Physics.Raycast(transform.position, rayDirectionForward, out RaycastHit hitForward, _maxRayDistance))
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

        rigidBody.velocity = Vector3.zero;
        _averageNormal /= _numberOfRayHits;
        rigidBody.AddForce(-_averageNormal * StickingForce, ForceMode.Impulse);
        transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.right, _averageNormal), _averageNormal);
    }

    private void HandleLandingPrompt()
    {
        // Handle prompt visibility
        if (_numberOfRayHits == 0)
        {
            StickPrompt.SetActive(false);
        }
        else if (_numberOfRayHits > 0)
        {
            StickPrompt.SetActive(true);
            StickPrompt.transform.rotation = Camera.main.transform.rotation;
        }

        // Handle prompt colour and text
        Image promptImage = StickPrompt.GetComponent<Image>();
        TextMeshProUGUI stickPromptText = StickPrompt.GetComponentInChildren<TextMeshProUGUI>();
        
        if (!Sticking)
        {
            promptImage.color = new Color(0.2563053f, 0.7075472f, 0.1512993f);
            stickPromptText.text = "X to stick";
            HeadingArrow.SetActive(false);
        }
        else if (Sticking)
        {
            promptImage.color = Color.grey;
            stickPromptText.text = "X to un-stick";
            HeadingArrow.SetActive(true);
        }
    }
}