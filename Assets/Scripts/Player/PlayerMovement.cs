using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    
    public Vector3 Velocity { get {
            return rigidBody2d.velocity;
        }
    }

	private Rigidbody2D rigidBody2d;
	private Animator animator;

    [HideInInspector]
    public bool IsSpeedingUp = false;

    private int speed = 280;
    private int speedUp = 4;

    // We're assuming that player can touch max 2 elements at once
    private float activeGroundObjectPositionX;
    private float previousGroundObjectPositionX;

    // Use this for initialization
    public void Awake () {
		rigidBody2d = GetComponent<Rigidbody2D>();
		animator = GameObject.Find(NameContainer.PLAYER).GetComponent<Animator>();
	}
	
	// Update is called once per frame
	public void Update () {
        //float move = Input.GetAxis("Horizontal");

		float move = speed * Time.deltaTime;

		if (true == IsSpeedingUp) {
			move = move * speedUp;
		}

        rigidBody2d.velocity = new Vector2(move, rigidBody2d.velocity.y);
	
		animator.speed = move/2;

		animator.SetFloat(AnimationParamContainer.PLAYER_VELOCITY, rigidBody2d.velocity.x);
    }
}
