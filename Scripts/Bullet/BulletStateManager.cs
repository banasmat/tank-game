using UnityEngine;
using System.Collections;

public class BulletStateManager : MonoBehaviour {

	public enum State{Flying, Hit, Dead};

	private State state;

	private bool stateChanged = false;

	//TODO those will probably change (animation) and probably should be moved from here
	public Sprite bulletFlying;
	public Sprite bulletExplosion;


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
				spriteRenderer.sprite = bulletExplosion;

				//TODO this will be removed when animation is set
				spriteRenderer.color = new Color (255, 0, 0, 1);
				// Start 'explosion' process, disable movement (or maybe later set other movement)
				StartCoroutine(DieAfterHit());

				//TODO stop force
				//TODO add explosion force

				break;
			case State.Dead:
				Destroy (gameObject);
				return;
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
}
