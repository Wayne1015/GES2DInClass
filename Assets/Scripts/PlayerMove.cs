using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    [SerializeField]
    float jumpStrength = 10;

    [SerializeField]
    float movementspeed = 6.6f;

    [SerializeField]
    Transform GroundDetectPoint;

    [SerializeField]
    float GroundDetectRadius = 0.2f;

    [SerializeField]
    LayerMask whatCountsAsGrounds;


    private bool isOnGround;

    //[SerializeField]
    Rigidbody2D myRigidBody;
	// Use this for initialization
	void Start ()
    {
        Debug.Log("Called From Start.");
        //this code puts the player in the center
        //transform.position = new Vector3(0,0,0);
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateIsOnGround();
        Move();
        Jump();
    }

    private void UpdateIsOnGround()
    {
       Collider2D[] groundObjects = Physics2D.OverlapCircleAll(
            GroundDetectPoint.position, GroundDetectRadius, whatCountsAsGrounds);

        isOnGround = groundObjects.Length > 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, y: jumpStrength);
            isOnGround = false;
        }
    }

    private void Move()
    {
        //programming for horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        
        //Changes the velocity of the gameobject 

        //code for jumping
        myRigidBody.velocity = new Vector2(horizontalInput * movementspeed, myRigidBody.velocity.y);
    }


}
