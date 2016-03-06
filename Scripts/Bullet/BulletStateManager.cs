﻿using UnityEngine;
using System.Collections;

public class BulletStateManager : MonoBehaviour {

	public enum State{Flying, Hit, Dead};

	public float explosionForce = 5f;

	private State state;

	private bool stateChanged = false;

	//TODO those will probably change (animation) and probably should be moved from here
	public Sprite bulletFlying;
	public Sprite bulletExplosion;


	public void Awake(){
	}

	public void Start(){
		setState (State.Flying);
	}

	//TODO delete?
	public void setState(State newState){
		state = newState;
		stateChanged = true;
	}

	public State getState(){
		return state;
	}

	public void Update(){
		// Apply actions depending on state only if it has changed
		if(true == stateChanged){
			switch (state)
			{
			case State.Flying:
				GetComponent<SpriteRenderer> ().sprite = bulletFlying;
				break;
			case State.Hit:
				SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();
				Rigidbody2D rigidBody = GetComponent<Rigidbody2D> ();

				spriteRenderer.sprite = bulletExplosion;
				//TODO this will be removed when animation is set
				spriteRenderer.color = new Color (255, 0, 0, 1);

				// Stop bullet from moving
				rigidBody.gravityScale = 0;
				rigidBody.velocity = Vector3.zero;
				rigidBody.mass = 0;

				// Disable collision
				GetComponent<BoxCollider2D> ().enabled = false;

				Explode ();

				// Start 'explosion' process, disable movement (or maybe later set other movement)
				StartCoroutine (DieAfterHit ());
				break;
			case State.Dead:
				Destroy (gameObject);
				break;
			}
			// After action reset stateChanged
			stateChanged = false;
		}
	}

	/**
	 * After three seconds set enemy state to dead
	**/
	IEnumerator DieAfterHit(){
		yield return new WaitForSeconds (2);
		setState(State.Dead);
	}

	//TODO move to some other object?
	private void Explode(){

		//TODO not yet sure which to use
		//Rigidbody2D[] rigidBodies = GameObject.FindObjectsOfType<Rigidbody2D>();
		GameObject[] rigidBodies = GameObject.FindGameObjectsWithTag(TagContainer.ENEMY_TAG);

		foreach (GameObject r in rigidBodies) {

			if (Vector2.Distance(r.transform.position, transform.position) < 2 && r.tag != TagContainer.PLAYER_TAG && r.tag != TagContainer.BULLET_TAG) {
				float distanceX = r.transform.position.x - transform.position.x;
				float distanceY = r.transform.position.y - transform.position.y;

				//new Vector2(px, py).normalized * explosionForce / Vector2.Distance(r.transform.position
				r.GetComponent<Rigidbody2D>().AddForce(
					new Vector2(distanceX * explosionForce, distanceY * explosionForce), ForceMode2D.Impulse );
			}
		}
	}
}