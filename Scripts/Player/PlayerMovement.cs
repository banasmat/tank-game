using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rigidBody2d;
	private PlayerStateManager stateManager;

    //TODO disable controls? just move? 
	public float maxSpeed = 10f;
    //bool facingRight = true;

	// Use this for initialization
	void Awake () {
		rigidBody2d = GetComponent<Rigidbody2D>();
		stateManager = GetComponent<PlayerStateManager> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float move = Input.GetAxis("Horizontal");

		if (move > 0) {
			stateManager.setState (PlayerStateManager.State.Moving);
		} else {
			stateManager.setState (PlayerStateManager.State.Static);
		}
			

        rigidBody2d.velocity = new Vector2(move * maxSpeed, rigidBody2d.velocity.y);
	}
}
