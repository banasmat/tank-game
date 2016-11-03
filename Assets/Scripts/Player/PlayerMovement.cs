using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    
    public Vector3 Velocity { get {
            return rigidBody2d.velocity;
        }
    }

	private Rigidbody2D rigidBody2d;
	private Animator animator;

	public bool IsBreaking = false;

    private int speed = 140;
    private int slowDown = 2;

    // We're assuming that player can touch max 2 elements at once
    private float activeGroundObjectPositionX;
    private float previousGroundObjectPositionX;

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

        rigidBody2d.velocity = new Vector2(move, rigidBody2d.velocity.y);
	
		animator.speed = move/2;

		animator.SetFloat(AnimationParamContainer.PLAYER_VELOCITY, rigidBody2d.velocity.x);
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        // When player reaches new ground element
        if (coll.gameObject.tag == TagContainer.GROUND)
        {
            float x = coll.gameObject.transform.position.x;

            if (activeGroundObjectPositionX != x && previousGroundObjectPositionX != x)
            {
                EventManager.Instance.PostNotification(new GameEvent(EVENT_TYPE.PLAYER_TOUCHES_NEW_GROUND_ELEMENT, coll.gameObject.transform));

                previousGroundObjectPositionX = activeGroundObjectPositionX;
                activeGroundObjectPositionX = x;
            }
        }
    }
}
