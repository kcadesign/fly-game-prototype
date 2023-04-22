using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOffLanding : MonoBehaviour
{
    [Header("References")]
    //private Rigidbody rigidBody;
    private CapsuleCollider capsuleCollider;

    private float colliderOriginalSize;
    [SerializeField] private float colliderHoverDistance;
    public bool isTakingOff = false;


    void Start()
    {
        //rigidBody = GetComponent<Rigidbody>();

        capsuleCollider = GetComponent<CapsuleCollider>();
        colliderOriginalSize = capsuleCollider.radius;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isTakingOff = !isTakingOff;
        }

        if (isTakingOff)
        {
            capsuleCollider.radius = colliderHoverDistance;
        }
        else
        {
            capsuleCollider.radius = colliderOriginalSize;
        }
        
    }

}
