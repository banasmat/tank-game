using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 10f;

	private Rigidbody2D rigidBody2d;
	private Animator animator;

	private float downTime, pressTime = 0;
	public float maxPressTime = 1;

	private bool isBreaking = false;
	private InfoBar breakBar;

	// Use this for initialization
	public void Awake () {
		rigidBody2d = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();

        GameObject _breakBar = GameObject.Find(NameContainer.BREAK_BAR);
        // TODO this is to avoid null reference errors. Probably scene objects should be retrieved by one separate object that would provide some proxies in case elements are not on stage?
        if (null != _breakBar)
        {
            breakBar = _breakBar.GetComponent<InfoBar>();
        }
	}
	
	// Update is called once per frame
	public void FixedUpdate () {
        //float move = Input.GetAxis("Horizontal");

		float move = 1;

		if (true == isBreaking) {
			move = 0.5f;
		}

        rigidBody2d.velocity = new Vector2(move * maxSpeed, rigidBody2d.velocity.y);
	
		animator.speed = move;

		animator.SetFloat(AnimationParamContainer.PLAYER_VELOCITY, rigidBody2d.velocity.x);

		//TODO WARNING code duplication (FireBullet)

		// Break
		if (Input.GetKeyDown (KeyCode.RightControl)) {
			if (false == isBreaking) {
				isBreaking = true;

				downTime = Time.time;
			}
		}

		if (downTime > 0) {
			// Control Info Bar
			pressTime = Time.time - downTime;
			breakBar.SetBarValue (pressTime * (100/maxPressTime)); // We're passing percentage
		}

		if (Input.GetKeyUp (KeyCode.RightControl) || pressTime >= maxPressTime) {
		
			if (0 != downTime) {
				isBreaking = false;

				breakBar.SetBarValue (0);

				downTime = 0;
				pressTime = 0;
			}
		}
	}
}
