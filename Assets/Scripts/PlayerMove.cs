using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    [SerializeField]
    float movementspeed = 6.6f;

    //[SerializeField]
    Rigidbody2D myRigidBody;
	// Use this for initialization
	void Start () {
        Debug.Log("Called From Start.");
        //this code puts the player in the center
        //transform.position = new Vector3(0,0,0);
        myRigidBody = GetComponent<Rigidbody2D>();
        

        
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        //programming for horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Debug.Log("Horizontal Input " + horizontalInput);
        //Changes the velocity of the gameobject 
        myRigidBody.velocity = 
            new Vector2(horizontalInput * movementspeed, myRigidBody.velocity.y);
        //doesn't use the physics system rigidbody2D
        //transform.Translate(0.1f * horizontalInput, 0 ,0);

        //code for jumping
        if (Input.GetButtonDown("Jump"))
        {
            //crappy jump logic
            //don't use GetKey use GetAxis 
            //if (Input.GetKey(KeyCode.D))
            //{
            //    transform.Translate(new Vector3(0.1f, 0));
            //}
            transform.Translate(new Vector3(0, 5, 0));
        }
    }
}
