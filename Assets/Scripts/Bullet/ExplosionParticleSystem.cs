using UnityEngine;
using System.Collections;

public class ExplosionParticleSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		StartCoroutine (DestroyObject ());
	}
	
	private IEnumerator DestroyObject(){
		yield return new WaitForSeconds (3);
		Destroy (gameObject);
	}
}
