using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 10f;

    public Vector3 Velocity { get {
            return rigidBody2d.velocity;
        }
    }

	private Rigidbody2D rigidBody2d;
	private Animator animator;

	public bool IsBreaking = false;

    private int speed = 40;
    private int slowDown = 2;
    

	// Use this for initialization
	public void Awake () {
		rigidBody2d = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	public void Update () {
        //float move = Input.GetAxis("Horizontal");

		float move = speed * Time.deltaTime;

		if (true == IsBreaking) {
			move = move/slowDown;
		}

        rigidBody2d.velocity = new Vector2(move * maxSpeed, rigidBody2d.velocity.y);
	
		animator.speed = move;

		animator.SetFloat(AnimationParamContainer.PLAYER_VELOCITY, rigidBody2d.velocity.x);
    }
}
