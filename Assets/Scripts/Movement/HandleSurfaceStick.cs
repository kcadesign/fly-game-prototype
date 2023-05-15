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

    private void Update()
    {
        HandleLandPrompt();
    }


    private void FixedUpdate()
    {
        SetRaycastAngle();
        AddForceAgainstNormal();
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
        if (!_handlePlayerInput.ButtonSouthPressed)
        {
            Sticking = false;

        }
        else if(_handlePlayerInput.ButtonSouthPressed)
        {
            // Enact physics using raycast normal info
            if (_numberOfRayHits > 0)
            {
                rigidBody.velocity = Vector3.zero;
                _averageNormal /= _numberOfRayHits;
                rigidBody.AddForce(-_averageNormal * StickingForce, ForceMode.Impulse);
                rigidBody.useGravity = false;
                transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.right, _averageNormal), _averageNormal);
                Sticking = true;

            }
        }
    }

    private void HandleLandPrompt()
    {
        if (_numberOfRayHits > 0)
        {
            LandingPrompt.SetActive(true);

        }
        else if(_numberOfRayHits == 0)
        {
            LandingPrompt.SetActive(false);

        }
    }





    /*
    private void OnCollisionStay(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        ObjectToRotate.transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.right, normal), normal);
        rigidBody.velocity = Vector3.zero;
    }
    private void OnCollisionExit(Collision collision)
    {
        ObjectToRotate.transform.rotation = cameraRotation.rotation;
    }
    */
}



