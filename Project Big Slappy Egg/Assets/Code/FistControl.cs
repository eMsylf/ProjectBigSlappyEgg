using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistControl : MonoBehaviour
{
    public float xPos = 0f;
    public float yPos;
    public float moveSpeed;

    private ParticleSystem playerCharged;
    public static float chargeTimeInit = 10f;
    private float chargeTime;
    public float chargeSpeed = .8f;

    public Rigidbody2D rb2d;

    void Start ()
    {
        playerCharged = GetComponent<ParticleSystem>();
    }
	
	void Update ()
    {
        float verticalSpeed = Input.GetAxis("Vertical");
        yPos += verticalSpeed * moveSpeed;
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
            chargeTime -= chargeSpeed;
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
    /// Release your punch by releasing spacebar
    /// </summary>
    void ReleasePunch ()
    {
        chargeTime = chargeTimeInit;
        //var emission = playerCharged.emission;
        //emission.enabled = false;
        Debug.Log("PUNCH!");

        rb2d.AddForce(transform.forward * 10f);
        playerCharged.Stop();
    }

}
