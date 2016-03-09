using UnityEngine;
using System.Collections;

public class PlayerStateManager : MonoBehaviour {

	public enum State{Static, Moving, Hit, Dead};

	private State state;

	public float hitForce = 5f;

	private bool stateChanged = false;

	private SpriteRenderer spriteRenderer;
	private Rigidbody2D rigidBody;
	private Animator animator;
	private PlayerMovement playerMovement;
	private PlayerHealth playerHealth;
	private FireAmmunition fireAmmunition;

	//TODO those will probably change (animation) and probably should be moved from here
	public Sprite tankStatic;


	public void Awake(){
		spriteRenderer = GetComponent<SpriteRenderer> ();
		rigidBody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator>();
		playerMovement = GetComponent<PlayerMovement> ();
		playerHealth = GetComponent<PlayerHealth> ();
	}

	public void Start(){
		setState (State.Static);
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
			case State.Static:
				spriteRenderer.sprite = tankStatic;
				animator.SetBool ("Moving", false);
				break;
			case State.Moving:

				animator.SetBool ("Moving", true);

				spriteRenderer.sprite = null;
				playerMovement.enabled = true;
				break;
			case State.Hit:
				
				animator.SetTrigger ("Hit");

				//TODO amount should be taken from enemy
				playerHealth.TakeDamage (20);
				Debug.Log (playerHealth);
				//TODO these actions probably collide
				if (playerHealth.getHealth() > 0) {
					StartCoroutine (RecoverAfterHit ());
				} else {
					DieAfterHit();
				}

				break;
			case State.Dead:
				animator.SetBool ("Moving", false);
				animator.SetBool ("Dead", true);
				fireAmmunition.enabled = false;
				//spriteRenderer.sprite = tankDestroyed;
				break;
			}
			// After action reset stateChanged
			stateChanged = false;
		}
	}

	private void DieAfterHit(){
		setState(State.Dead);
		playerMovement.enabled = false;

		//TODO handle game over
	}

	IEnumerator RecoverAfterHit(){
		yield return new WaitForSeconds (1);
		setState(State.Moving);
	}

}
