using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSurfaceStick : PlayerMovementInitialise
{
    public float stickForce = 5;

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit))
        {

            Vector3 surfaceNormal = hit.normal;
            //Debug.Log(surfaceNormal);


            // Apply force to the rigidbody based on the surface normal
            rigidBody.AddForce(surfaceNormal * -stickForce);

        }

    }

}
