using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireScript : MonoBehaviour {

	//the object that will be spawned

	public GameObject Bullet;
	public int force;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Fire1")){//when the left mouse button is pressed
			FireBullet();//look for and use the fire bullet operation
		}
	}

	public void FireBullet(){
		//Clone of the bullet
		GameObject Clone;

		//spawning the bullet at position
		Clone = (Instantiate(Bullet, transform.position+1*transform.forward,transform.rotation)) as GameObject;
		//add force to the spawned objected
		Clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 0));
	}







}