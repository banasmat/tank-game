using UnityEngine;
using System.Collections;

public class BulletEventListener : MonoBehaviour {

	public GameObject explosionPrefab;			// Prefab of explosion effect.
	//private ParticleSystem explosionFX;		// Reference to the particle system of the explosion effect.
	public GameObject explosionParticleSystemPrefab;



	void Awake(){
		//TODO implement particle system
//		explosionFX = GameObject.FindGameObjectWithTag("ExplosionFX").GetComponent<ParticleSystem>();
	}

	void OnCollisionEnter2D(Collision2D coll) {

		//TODO particle pool

		// When bullet hits enemy
		if (coll.gameObject.tag == TagContainer.ENEMY) {

			// TODO maybe just use on collision enter in enemy
			EventManager.Instance.PostNotification (new GameEvent (EVENT_TYPE.BULLET_HITS_ENEMY));

			// Red particles
			CreateExplosion ();
			ParticleSystem _explosionParticleSystem = CreateExplosionParticleSystem ();

			//TODO delegate to separate function, remove code duplication, move color to const
			_explosionParticleSystem.startColor = new Color(1, 0, 0, 1);
			_explosionParticleSystem.Play ();
			Destroy (gameObject);
		}

		if (coll.gameObject.tag == TagContainer.GROUND) {

			// Brown particles
			CreateExplosion ();
			ParticleSystem _explosionParticleSystem = CreateExplosionParticleSystem ();

			//TODO delegate to separate function, remove code duplication, move color to const
			_explosionParticleSystem.startColor = new Color(0.54f, 0.27f, 0.07f, 1);
			_explosionParticleSystem.Play ();
			Destroy (gameObject);

		}


	}

	//TODO move to some other object?
	private void CreateExplosion(){
		GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation) as GameObject;
	}

	private ParticleSystem CreateExplosionParticleSystem(){
		GameObject explosionParticleSystem = Instantiate(explosionParticleSystemPrefab, transform.position, transform.rotation) as GameObject;
		return explosionParticleSystem.GetComponent<ParticleSystem> ();
	}


}