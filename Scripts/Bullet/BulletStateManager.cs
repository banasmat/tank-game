using UnityEngine;
using System.Collections;

public class BulletStateManager : MonoBehaviour {

	public enum State{Flying, Hit, Dead};

	public float explosionForce = 5f;

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

				// Stop bullet from moving
				Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
				rigidbody.velocity = Vector3.zero;
				rigidbody.mass = 0;

				//TODO add explosion force

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

	//
	private void Explode(){

		Rigidbody2D[] rigidBodies = GameObject.FindObjectsOfType<Rigidbody2D>();

		foreach (Rigidbody2D r in rigidBodies) {
			if (Vector2.Distance(r.transform.position, transform.position) < 6 && r.tag != TagContainer.PLAYER_TAG) {
				float px = r.transform.position.x - transform.position.x;
				float py = r.transform.position.y - transform.position.y;
				r.AddForce(new Vector2(px, py).normalized * explosionForce / Vector2.Distance(r.transform.position, transform.position));
			}
		}
	}
}
