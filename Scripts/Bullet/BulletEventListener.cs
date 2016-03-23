using UnityEngine;
using System.Collections;

public class BulletEventListener : MonoBehaviour {

	public float explosionForce = 5f;

	private Rigidbody2D rigidBody;
	private Animator animator;
	private BoxCollider2D boxCollider2d;

	void Awake(){
		rigidBody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		boxCollider2d = GetComponent<BoxCollider2D> ();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		// When bullet hits enemy
		if (coll.gameObject.tag == TagContainer.ENEMY) {

			// TODO maybe just use on collision enter in enemy
			EventManager.Instance.PostNotification (new GameEvent (EVENT_TYPE.BULLET_HITS_ENEMY));

			Explode ();
		}

		if (coll.gameObject.tag == TagContainer.GROUND) {

			Explode ();
		}
	}

	//TODO move to some other object?
	private void Explode(){

		animator.SetTrigger (AnimationParamContainer.BULLET_EXPLODE);

		// Stop bullet from moving
		rigidBody.gravityScale = 0;
		rigidBody.velocity = Vector3.zero;
		rigidBody.mass = 0;
		boxCollider2d.enabled = false;

		//TODO not yet sure which to use
		//Rigidbody2D[] rigidBodies = GameObject.FindObjectsOfType<Rigidbody2D>();
		GameObject[] rigidBodies = GameObject.FindGameObjectsWithTag(TagContainer.ENEMY);

		foreach (GameObject r in rigidBodies) {

			if (Vector2.Distance(r.transform.position, transform.position) < 2 && r.tag != TagContainer.PLAYER && r.tag != TagContainer.BULLET) {
				float distanceX = r.transform.position.x - transform.position.x;
				float distanceY = r.transform.position.y - transform.position.y;

				//new Vector2(px, py).normalized * explosionForce / Vector2.Distance(r.transform.position
				r.GetComponent<Rigidbody2D>().AddForce(
					new Vector2(distanceX * explosionForce, distanceY * explosionForce), ForceMode2D.Impulse );
			}
		}

		StartCoroutine (DestroyObject ());
	}

	private IEnumerator DestroyObject(){
		yield return new WaitForSeconds (2);
		Destroy (gameObject);
	}
}