using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSurfaceStick : PlayerMovementInitialise
{
    public float stickForce = 5;
    public int numRays = 5;
    public float maxRayDistance = 1f;
    public float raycastAngle = 360f;

    private void FixedUpdate()
    {
        Vector3 averageNormal = Vector3.zero;
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
            rigidBody.AddForce(averageNormal * -stickForce);
        }
    }
}

