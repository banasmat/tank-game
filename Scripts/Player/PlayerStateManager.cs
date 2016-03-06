using UnityEngine;
using System.Collections;

public class PlayerStateManager : MonoBehaviour {

	public enum State{Moving, Hit, Dead};

	private State state;

	public float hitForce = 5f;

	private bool stateChanged = false;

	private PlayerMovement playerMovement;
	private SpriteRenderer spriteRenderer;

	//TODO those will probably change (animation) and probably should be moved from here
	public Sprite tankMoving;
	public Sprite tankHit;
	public Sprite tankDestroyed;

	public void Awake(){
		playerMovement = GetComponent<PlayerMovement> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	public void Start(){
		setState (State.Moving);
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
			case State.Moving:
				spriteRenderer.sprite = tankMoving;
				playerMovement.enabled = true;
				break;
			case State.Hit:
				Rigidbody2D rigidBody = GetComponent<Rigidbody2D> ();

				spriteRenderer.sprite = tankHit;

				PlayerHealth playerHealth = GetComponent<PlayerHealth> ();
				//TODO amount should be taken from enemy
				playerHealth.TakeDamage (20);

				//TODO these actions probably collide
				if (playerHealth.getHealth() > 0) {
					StartCoroutine (RecoverAfterHit ());
				} else {
					DieAfterHit();
				}

				break;
			case State.Dead:
				spriteRenderer.sprite = tankDestroyed;
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
