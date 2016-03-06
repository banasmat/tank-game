using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    //TODO disable controls? just move? 
	public float maxSpeed = 10f;
    //bool facingRight = true;

	// Use this for initialization
	void Awake () {
		//Wait with execution for the call from PlayerStateManager
		enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float move = Input.GetAxis("Horizontal");
        Rigidbody2D rigidBody2d = GetComponent<Rigidbody2D>();

        rigidBody2d.velocity = new Vector2(move * maxSpeed, rigidBody2d.velocity.y);
	}
}
