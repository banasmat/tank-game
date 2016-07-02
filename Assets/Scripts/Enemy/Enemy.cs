using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//TODO strength will depend on enemy type, for now we're hardcoding it
	public int strength = 20;

	private Rigidbody2D rigidBody;

	public void Awake(){
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
	}

	public void addExplosionComponents(){
		addComponents (transform.Find ("Head").gameObject);
		addComponents (transform.Find ("RightHandPivot").gameObject);
		addComponents (transform.Find ("LeftLegPivot").gameObject);
	}

	private void addComponents(GameObject _gameObject){
		//TODO maybe it's better to ADD rigidbody programatically
		Rigidbody2D _rigidBody = _gameObject.AddComponent<Rigidbody2D> ();
		//Collider2D _collider2D = _gameObject.AddComponent<BoxCollider2D> ();

		//_rigidBody.tag = TagContainer.ENEMY;
		_rigidBody.drag = 5;


	}


}
