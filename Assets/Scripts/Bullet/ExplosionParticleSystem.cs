using UnityEngine;
using System.Collections;

public class ExplosionParticleSystem : MonoBehaviour {
	private ObjectPoolManager objectPoolManager;

	public void Awake(){
		objectPoolManager = GameObject.Find (NameContainer.OBJECT_POOL_MANAGER).GetComponent<ObjectPoolManager>();
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (DestroyObject ());
	}
	
	private IEnumerator DestroyObject(){
		yield return new WaitForSeconds (3);
		objectPoolManager.Add (gameObject);
	}
}
