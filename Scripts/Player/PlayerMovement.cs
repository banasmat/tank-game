using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rigidBody2d;
	private Animator animator;

    //TODO disable controls? just move? 
	public float maxSpeed = 10f;

	// Use this for initialization
	public void Awake () {
		rigidBody2d = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	public void FixedUpdate () {
        float move = Input.GetAxis("Horizontal");

        rigidBody2d.velocity = new Vector2(move * maxSpeed, rigidBody2d.velocity.y);
	
		animator.speed = move;

		animator.SetFloat(AnimationParamContainer.PLAYER_VELOCITY, rigidBody2d.velocity.x);
	}
}
