using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistControl : MonoBehaviour
{
    // Movement variables
    public float moveSpeed;
    private float verticalMovement;

    // Punch charging variables
    private ParticleSystem playerCharged;
    public float chargeTicks = 100f;
    private float chargeTickPerFrame = 1f;
    private float chargeTime = 100f;
    bool fullyCharged;
    int fullyChargedBonus;

    // Punch launching & reset variables
    public Rigidbody2D rb2d;
    public float startForce;
    Vector2 startPosition;
    Vector2 currentPosition;
    public float resetTime;
    public bool beginReset;

    public float playerDirection;

    void Start ()
    {
        // Assign particlesystem component
        playerCharged = GetComponent<ParticleSystem>();

        // Store object starting position to reset after a punch
        startPosition = new Vector2(transform.position.x, transform.position.y);
        
        print(transform.position.x + " " + transform.position.y);

        // Decided to assign moveSpeed here because it's used by two separate objects. Changing it in the editor would be more work.
        moveSpeed = 15f;
        startForce = 40f;
        resetTime = .2f;

        // This damn particle system plays every time I charge a punch for the first time.
        playerCharged.Stop();

        beginReset = false;
    }
	
	void Update ()
    {
        //print(Input.GetAxis("Vertical_P1"));
        //print(Input.GetAxis("Vertical_P2"));
        currentPosition.x = transform.position.x;
        currentPosition.y = transform.position.y;

        // Player can only move if not throwing a punch
        
        if (gameObject.CompareTag("P1"))
        {
            transform.Translate(0f, (Input.GetAxis("Vertical_P1") * moveSpeed) * Time.deltaTime, 0f);
            // Charging a punch. If the player releases the spacebar, a punch is thrown.
            if (Input.GetKey(KeyCode.D))
            {
                ChargePunch();
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                playerDirection = 1;
                ReleasePunch();
            }
        }
        if (gameObject.CompareTag("P2"))
        {
            transform.Translate(0f, (Input.GetAxis("Vertical_P2") * moveSpeed) * Time.deltaTime, 0f);
            // Charging a punch. If the player releases the spacebar, a punch is thrown.
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                ChargePunch();
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                playerDirection = -1;
                ReleasePunch();
            }
        }
        //ResetPosition();

        currentPosition.y = Mathf.Clamp(transform.position.y, -4f, 4f);
        transform.position = currentPosition;
    }
    
    // Charge a punch by holding down spacebar
    void ChargePunch ()
    {
        
        if (chargeTime >= 0)
        {
            chargeTime -= chargeTickPerFrame;
            Debug.Log("Charge time while charging = " + chargeTime);
            Debug.Log("Charging");
            if (playerCharged.isPlaying == false)
            {
                playerCharged.Play();
            }
        } else
        {
            Debug.Log("Charge time after completion = " + chargeTime);
            Debug.Log("CHARGED!");
            fullyCharged = true;

            playerCharged.Play();
        }
    }
    
    // Throw punch by releasing spacebar
    void ReleasePunch ()
    {
        chargeTime = chargeTicks;
        Debug.Log("PUNCH!");

        //startForce = chargeTicks - chargeTime;
        if (fullyCharged == true)
        {
            fullyChargedBonus = 2;
        }
        else
        {
            fullyChargedBonus = 1;
        }

        rb2d.AddForce(transform.right * startForce * playerDirection * fullyChargedBonus, ForceMode2D.Impulse);

        if (playerCharged.isPlaying == true)
        {
            playerCharged.Stop();
        }
        StartCoroutine(Reset());
    }

    IEnumerator Reset ()
    {
        yield return new WaitForSeconds(resetTime);

        rb2d.velocity = Vector2.zero;
        
        beginReset = true;
        Debug.Log("Position reset from: " + currentPosition.x + " to starting position: " + startPosition.x);
        if (beginReset == true)
        {
            transform.position = new Vector2(startPosition.x, currentPosition.y);
        }
        beginReset = false;

    }

    /*
    void ResetPosition ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

        }
    }
    */

}
