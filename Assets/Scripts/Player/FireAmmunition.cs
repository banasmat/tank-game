using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireAmmunition : MonoBehaviour {

	public GameObject Bullet;
	public int bulletForce = 800;

	private ObjectPool objectPool;
	private ObjectPoolManager objectPoolManager;

	void Awake(){
		objectPoolManager = GameObject.FindGameObjectWithTag (TagContainer.OBJECT_POOL_MANAGER).GetComponent<ObjectPoolManager>();
		objectPoolManager.CreatePool (Bullet, 10);
	}

	void Update () {

		if (Input.GetButtonDown("Fire1")){//when the left mouse button is pressed
			FireBullet();//look for and use the fire bullet operation
		}
	}

	public void FireBullet(){
		//Clone of the bullet
		GameObject bulletClone;


		bulletClone = objectPoolManager.Retrieve(Bullet, transform.position+1*transform.forward, transform.rotation);


		//bulletClone.gameObject.tag = TagContainer.BULLET;

		//add force to the spawned objected
		bulletClone.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletForce);

		//TODO block firing until reloaded
	}







}