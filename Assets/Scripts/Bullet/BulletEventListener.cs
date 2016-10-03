using UnityEngine;
using System.Collections;

public class BulletEventListener : MonoBehaviour {

	public GameObject explosionPrefab;			// Prefab of explosion effect.
	//private ParticleSystem explosionFX;		// Reference to the particle system of the explosion effect.

	private ExplosionParticleManager explosionParticleManager;
	private ObjectPoolManager objectPoolManager;

	void Awake(){
//		explosionFX = GameObject.FindGameObjectWithTag("ExplosionFX").GetComponent<ParticleSystem>();
		explosionParticleManager = ExplosionParticleManager.Instance;
		objectPoolManager = ObjectPoolManager.Instance;
        //TODO probably move it to FireAmmunition (which is called only once)
        objectPoolManager.CreatePool (explosionPrefab, 5);
	}

	void OnCollisionEnter2D(Collision2D coll) {

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

	private void CreateExplosion(){
		objectPoolManager.Retrieve(explosionPrefab, transform.position, transform.rotation);
	}


}