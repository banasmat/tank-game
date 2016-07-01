using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public float explosionRadius = 10f;
	public float explosionForce = 100f;


	void Awake () {
	}
	
	void Start () {
		
		Explode ();
	}

	private void Explode(){
		// Find all the colliders on the Enemies layer within the explosionRadius.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

		Debug.Log (colliders.Length);
		// For each collider...
		foreach(Collider2D en in colliders)
		{
			if(en.gameObject.tag == TagContainer.ENEMY)
			{
				//en.gameObject.GetComponent<Enemy> ().addExplosionComponents ();
			//TODO for now exploding enemies are handled by EnemyEventListener
			// Check if it has a rigidbody (since there is only one per enemy, on the parent).
				Rigidbody2D rb = en.GetComponent<Rigidbody2D>();
				Debug.Log (rb);
				if(rb != null)
				{
					//rb.WakeUp ();
					// Find the Enemy script and set the enemy's health to zero.
					//rb.gameObject.GetComponent<Enemy>().HP = 0;

					// Find a vector from the explosion to the enemy.
					Vector3 deltaPos = rb.transform.position - transform.position;

					// Apply a force in this direction with a magnitude of explosionForce.
					Vector3 force = deltaPos.normalized * explosionForce;
					rb.AddForce(force);
				}
			}
		}

		// Set the explosion effect's position to the explosion's position and play the particle system.
		//explosionFX.transform.position = transform.position;
		//explosionFX.Play();

		// Instantiate the explosion prefab.
		//Instantiate(explosion,transform.position, Quaternion.identity);

		// Play the explosion sound effect.
		//AudioSource.PlayClipAtPoint(boom, transform.position);

		// Destroy the explosion.
		StartCoroutine (DestroyObject ());
	}

	private IEnumerator DestroyObject(){
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
	}
}
