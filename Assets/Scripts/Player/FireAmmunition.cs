using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireAmmunition : MonoBehaviour {

	public GameObject Bullet;
	public int bulletForce = 800;

	private ObjectPool objectPool;

	void Awake(){
		objectPool = new ObjectPool (20);
	}

	void Update () {

		if (Input.GetButtonDown("Fire1")){//when the left mouse button is pressed
			FireBullet();//look for and use the fire bullet operation
		}
	}

	public void FireBullet(){
		//Clone of the bullet
		GameObject bulletClone;

		//FIXME how do we add bullets to the pool? Create separate GameObject BulletsPool??
		try{
			bulletClone = objectPool.retrieve();
		} catch (UnityException){
			//spawning the bullet at position
			bulletClone = (Instantiate(Bullet, transform.position+1*transform.forward, transform.rotation)) as GameObject;
		}

		//bulletClone.gameObject.tag = TagContainer.BULLET;

		//add force to the spawned objected
		bulletClone.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletForce);

		//TODO block firing until reloaded
	}







}