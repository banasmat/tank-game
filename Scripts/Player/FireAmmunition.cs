using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireAmmunition : MonoBehaviour {

	//the object that will be spawned

	public GameObject Bullet;
	public int bulletForce = 800;

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
		GameObject bulletClone;

		//spawning the bullet at position
		bulletClone = (Instantiate(Bullet, transform.position+1*transform.forward, transform.rotation)) as GameObject;

//		Clone.gameObject.tag = TagContainer.BULLET_TAG;

		//add force to the spawned objected
		bulletClone.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletForce);
	}







}