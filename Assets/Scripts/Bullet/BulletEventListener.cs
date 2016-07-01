using UnityEngine;
using System.Collections;

public class BulletEventListener : MonoBehaviour {

	public GameObject explosionPrefab;			// Prefab of explosion effect.
	//private ParticleSystem explosionFX;		// Reference to the particle system of the explosion effect.

	void Awake(){
		//TODO implement particle system
//		explosionFX = GameObject.FindGameObjectWithTag("ExplosionFX").GetComponent<ParticleSystem>();
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
		Destroy (gameObject);

		GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation) as GameObject;
	}


}