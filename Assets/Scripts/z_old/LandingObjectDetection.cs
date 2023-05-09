using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingObjectDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void OnTriggerEnter(Collider other)
    {
        // Get the closest point on the collider's bounds to the point of contact
        Vector3 closestPoint = other.ClosestPointOnBounds(transform.position);

        

        // Use the closestPoint vector to determine the location of the trigger entry
        Debug.Log($"{gameObject.name}'s trigger entered at {closestPoint} by {other.name}");
    }


}
