using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSurfaceStick : PlayerMovementInitialise
{
    public GameObject render;

    public Transform cameraRotation;

    Vector3 averageNormal = Vector3.zero;


    public float stickingForce = 5;
    public int numRays = 5;
    public float maxRayDistance = 1f;
    public float raycastAngle = 360f;

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        int numHits = 0;

        for (int i = 0; i < numRays; i++)
        {
            Vector3 rayDirection = Quaternion.AngleAxis(i * raycastAngle / (numRays - 1) - raycastAngle / 2, transform.right) * -transform.up;

            if (Physics.Raycast(transform.position, rayDirection, out RaycastHit hit, maxRayDistance))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
                averageNormal += hit.normal;
                numHits++;
            }
        }

        for (int i = 0; i < numRays; i++)
        {
            Vector3 rayDirectionRotated = Quaternion.AngleAxis(i * raycastAngle / (numRays - 1) - raycastAngle / 2, transform.forward) * -transform.up;

            if (Physics.Raycast(transform.position, rayDirectionRotated, out RaycastHit hit, maxRayDistance))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
                averageNormal += hit.normal;
                numHits++;
            }
        }

        if (numHits > 0)
        {
            averageNormal /= numHits;
            rigidBody.AddForce(averageNormal * -stickingForce);
            //Debug.Log(averageNormal);

        }
        

    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        render.transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.right, normal), normal);

    }
    private void OnCollisionExit(Collision collision)
    {
        render.transform.rotation = cameraRotation.rotation;
    }

}



