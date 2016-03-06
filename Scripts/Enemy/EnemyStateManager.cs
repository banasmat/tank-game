using UnityEngine;
using System.Collections;

public class EnemyStateManager : MonoBehaviour {

	public enum State{Running, Hit, Dead};

	private State state;

	private bool stateChanged = false;

	EnemyMovement enemyMovement;


	//TODO those will probably change (animation) and probably should be moved from here
	public Sprite enemyRunning;
	public Sprite enemyHit;

	// Constructor (?)
	public void Awake (){
		enemyMovement = GetComponent<EnemyMovement> ();
	}

	public void Start(){
		setState (State.Running);
	}

	public void setState(State newState){
		state = newState;

		//TODO when to set back to false???
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
			case State.Running:
				GetComponent<SpriteRenderer> ().sprite = enemyRunning;
				enemyMovement.enabled = true;
				break;
			case State.Hit:
				GetComponent<SpriteRenderer> ().sprite = enemyHit;
				GetComponent<BoxCollider2D> ().enabled = false ;
				//TODO maybe can be done with some animation state tools?
				// Start 'dying' process, disable movement (or maybe later set other movement)
				StartCoroutine(DieAfterHit());
				enemyMovement.enabled = false;
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
		yield return new WaitForSeconds (3);
		setState(State.Dead);
	}

}
