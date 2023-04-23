using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void PlayerFlying(bool isFlying);
    public static event PlayerFlying playerFlying;

    public delegate void PlayerWalking(bool isWalking);
    public static event PlayerWalking playerWalking;

    [Header("References")]
    private PlayerWalk playerWalk;
    private PlayerFly playerFly;
    private TakeOffLanding takeOffLanding;
    private FlyUp flyUp;
    
    void Start()
    {
        playerWalk = GetComponent<PlayerWalk>();
        playerFly = GetComponent<PlayerFly>();
        takeOffLanding = GetComponent<TakeOffLanding>();
        flyUp = GetComponent<FlyUp>();
    }

    private void Update()
    {
        if (takeOffLanding.isTakingOff)
        {
            playerWalk.enabled = false;
            playerFly.enabled = true;
        }
        else
        {
            playerWalk.enabled = true;
            playerFly.enabled = false;
        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        playerWalk.enabled = true;
        playerFly.enabled = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        playerWalk.enabled = true;
        playerFly.enabled = false;

    }

    private void OnCollisionExit(Collision collision)
    {
        playerWalk.enabled = false;
        playerFly.enabled = true;

    }
    */

}
