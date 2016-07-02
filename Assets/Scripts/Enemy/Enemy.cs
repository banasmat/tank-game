using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//TODO strength will depend on enemy type, for now we're hardcoding it
	public int strength = 20;

	private Rigidbody2D rigidBody;

	public void Awake(){
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
	}



}
