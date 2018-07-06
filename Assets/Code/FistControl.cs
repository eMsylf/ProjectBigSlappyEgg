using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistControl : MonoBehaviour
{
    public float xPos = 0f;
    public float yPos;
    public float moveSpeed;

    private ParticleSystem playerCharged;
    public float chargeTicks = 100f;
    private float chargeTickPerFrame = 1f;
    private float chargeTime;

    private float verticalMovement;

    public Rigidbody2D rb2d;
    public float startForce = 15f;

    void Start ()
    {
        playerCharged = GetComponent<ParticleSystem>();
    }
	
	void Update ()
    {
        verticalMovement = Input.GetAxis("Vertical");
        yPos += verticalMovement * moveSpeed;
        transform.position = new Vector3(xPos, yPos);
        //Debug.Log(verticalSpeed);

        if (Input.GetKey("space"))
        {
            ChargePunch();
        }
        else if (Input.GetKeyUp("space"))
        {
            ReleasePunch();
        }
    }

    /// <summary>
    /// Charge punch by holding down spacebar
    /// </summary>
    void ChargePunch ()
    {
        if (chargeTime >= 0)
        {
            chargeTime -= chargeTickPerFrame;
            Debug.Log("ayy = " + chargeTime);
            Debug.Log("Charging");
        } else
        {
            Debug.Log("lmao = " + chargeTime);
            Debug.Log("CHARGED!");


            playerCharged.Play();
        }
    }

    /// <summary>
    /// Throw punch by releasing spacebar
    /// </summary>
    void ReleasePunch ()
    {
        chargeTime = chargeTicks;
        //var emission = playerCharged.emission;
        //emission.enabled = false;
        Debug.Log("PUNCH!");

        rb2d.AddForce(transform.up * startForce, ForceMode2D.Impulse);
        
        playerCharged.Stop();
    }

}
