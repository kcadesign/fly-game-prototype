using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [Header("References")]
    private Rigidbody rigidBody;

    public bool isHoverToggled;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            isHoverToggled = !isHoverToggled;
        }

        


        if (isHoverToggled)
        {
            rigidBody.isKinematic = true;
        }
        else
        {
            rigidBody.isKinematic = false;
        }

        

    }
}
