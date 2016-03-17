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
		fireAmmunition = GetComponent<FireAmmunition> ();
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
			case State.Dead:
				animator.SetBool ("Moving", false);
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
