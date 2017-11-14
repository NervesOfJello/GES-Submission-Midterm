using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    //publicly editable fields
    [SerializeField]
    float movementSpeed = 1f;

    [SerializeField]
    float jumpStrength = 10f;

    [SerializeField]
    Transform groundDetectPoint;

    [SerializeField]
    float groundDetectRadius = 0.2f;

    [SerializeField]
    LayerMask whatCountsAsGround;

    [SerializeField]
    float jetpackStrength = 210f;    

    [SerializeField]
    float fuelMaximum = 100f;

    public static float jetpackFuel = 0f;

    //input booleans
    private bool isOnGround;

    //checking input in update booleans to transfer to FixedUpdate
    private bool canJump;
    private bool canJetpack;

    //various forces for adding
    private Vector2 jumpForce;
    private Vector2 jetpackForce;

    //component variables
    Rigidbody2D myRigidBody;
    AudioSource audioSource;

    //UI variables
    private Text fuelText;

    //input variables
    private float horizontalInput;
    private float jetpackInput;

    // Use this for initialization
    void Start () {
        //this code teleports the gameobject to a new locations
        //transform.position = new Vector3(0, 0, 0);

        //initialize component variables
        myRigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        fuelText = GameObject.Find("FuelText").GetComponent<Text>();

        //initialize vector variables
        jumpForce = new Vector2(0, jumpStrength);
        jetpackForce = new Vector2(0, jetpackStrength);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //update functions
        UpdateIsOnGround();
        RefuelOnGround();
        CheckFuel();

        //update input functions, input is referenced in FixedUpdate
        GetMovementInput();
        GetJumpInput();
        GetJetpackInput();

        

    }

    //uses time.DeltaTime by default
    private void FixedUpdate()
    {
        //actual functions for movement taking input from the update() functions
        Move();
        Jump();
        Jetpack();
        
    }

    //if you're on the ground, refuel up to the fuel maximum
    private void RefuelOnGround()
    {
        if(isOnGround && jetpackFuel < fuelMaximum)
        {
            jetpackFuel += 2;
            //Debug.Log("Fuel Remaining: " + jetpackFuel);
        }
    }
    //make sure you can't refuel past the maximum
    private void CheckFuel()
    {
        //update FuelText
        fuelText.text = "Fuel: " + jetpackFuel;

        //set fuel to max if it is refuelled above it
        if (jetpackFuel > fuelMaximum)
        {
            jetpackFuel = fuelMaximum;
        }
    }

    private void GetJetpackInput()
    {
        if (Input.GetAxis("Jetpack") > 0 && jetpackFuel > 0)
        {
            //Debug.Log("Fuel Remaining: " + jetpackFuel);
            jetpackFuel -= 1;
        }

        if (jetpackFuel > 0)
        {
        jetpackInput = Input.GetAxis("Jetpack");
        }
        else
        {
            jetpackInput = 0;
        }
        
        
    }

    //check for jump input
    private void GetJumpInput()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            canJump = true;
        }
    }

    //check for move input
    private void GetMovementInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }


    private void UpdateIsOnGround()
    {
        Collider2D[] groundObjects = Physics2D.OverlapCircleAll(groundDetectPoint.position, groundDetectRadius, whatCountsAsGround);

        isOnGround = groundObjects.Length > 0;
    }

    private void Move()
    {
        //don't use input.getkey, use input.GetButton and GetAxis        

        //takes input from the getMoveInput method, so the following line is unnecessary
        //float horizontalInput = Input.GetAxis("Horizontal");

        myRigidBody.velocity = new Vector2(horizontalInput * movementSpeed, myRigidBody.velocity.y);
    }

    private void Jump()
    {
        //better jump logic
        if (canJump)
        {
            audioSource.Play();

            canJump = false;
            myRigidBody.AddForce(jumpForce);
            isOnGround = false;

        }
        
    }

    private void Jetpack()
    {
                
        myRigidBody.AddForce(jetpackInput * jetpackForce);
    }

}