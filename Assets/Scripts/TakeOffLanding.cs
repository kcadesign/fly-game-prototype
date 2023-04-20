using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOffLanding : MonoBehaviour
{
    private CapsuleCollider capsuleCollider;

    private float colliderOriginalSize;
    [SerializeField] private float colliderHoverSize;
    [SerializeField] private bool isHoverToggled;


    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        colliderOriginalSize = capsuleCollider.radius;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isHoverToggled = !isHoverToggled;
        }

        if (!isHoverToggled)
        {
            capsuleCollider.radius = colliderHoverSize;
        }
        else
        {
            capsuleCollider.radius = colliderOriginalSize;
        }
    }
}
