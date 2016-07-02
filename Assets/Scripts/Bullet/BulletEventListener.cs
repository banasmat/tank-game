using UnityEngine;
using System.Collections;

public class BulletEventListener : MonoBehaviour {

	public GameObject explosionPrefab;			// Prefab of explosion effect.
	//private ParticleSystem explosionFX;		// Reference to the particle system of the explosion effect.

	private ExplosionParticleManager explosionParticleManager;


	void Awake(){
		//TODO implement particle system
//		explosionFX = GameObject.FindGameObjectWithTag("ExplosionFX").GetComponent<ParticleSystem>();
		explosionParticleManager = GameObject.Find(NameContainer.EXPLOSION_PARTICLE_MANAGER).GetComponent<ExplosionParticleManager>();
	}

	void OnCollisionEnter2D(Collision2D coll) {

		//TODO particle pool

		// When bullet hits enemy
		if (coll.gameObject.tag == TagContainer.ENEMY) {

			// Red particles
			CreateExplosion ();

			Destroy (gameObject);
		}

		if (coll.gameObject.tag == TagContainer.GROUND) {

			// Brown particles
			CreateExplosion ();

			explosionParticleManager.setColor (new Color (0.54f, 0.27f, 0.07f, 1));
			explosionParticleManager.createExplosionParticleSystem (transform);

			Destroy (gameObject);
		}
	}

	//TODO move to some other object?
	private void CreateExplosion(){
		GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation) as GameObject;
	}


}