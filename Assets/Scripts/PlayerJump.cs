using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("References")]
    private Rigidbody rigidBody;

    [SerializeField] private float jumpForce;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionStay(Collision collision)
    {
        print(collision.gameObject.name);
        // Check if collision occurred
        if (collision.gameObject)
        {
            float verticalInput = Input.GetAxisRaw("Jump");
            Vector3 verticalForce = jumpForce * verticalInput * Vector3.up;

            if (verticalForce.magnitude == 0)
            {
                verticalForce = Vector3.zero;

            }
            else if (verticalInput != 0)
            {
                rigidBody.AddForce(verticalForce, ForceMode.Impulse);
            }
            
            
            

        }
    }
    /*
    private void Jump()
    {
        
        print(jumpInput);
        // Check if jump button is pressed and player is colliding with an object
        if (jumpInput)
        {
            // Add force to rigidbody to simulate jump
            StartCoroutine(JumpProcess());
        }
    }

    IEnumerator JumpProcess()
    {
        // Wait for short delay before setting velocity to zero and disabling gravity
        yield return new WaitForSeconds(0.1f);
        rigidBody.velocity = Vector3.zero;
        rigidBody.useGravity = false;
    }
    */

}
