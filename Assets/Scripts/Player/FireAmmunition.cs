using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireAmmunition : MonoBehaviour {

	public GameObject bulletPrefab;
	private Rigidbody2D bulletPrefabRigidBody;
	public int bulletForce = 800;

	private ObjectPool objectPool;
	private ObjectPoolManager objectPoolManager;



	void Awake(){
		//TODO at the moment we're not using object pool here. Probably remove.
		objectPoolManager = GameObject.FindGameObjectWithTag (NameContainer.OBJECT_POOL_MANAGER).GetComponent<ObjectPoolManager>();
		objectPoolManager.CreatePool (bulletPrefab, 10);

		bulletPrefabRigidBody = bulletPrefab.GetComponent<Rigidbody2D> ();
	}

	void Update () {

		if (Input.GetButtonDown("Fire1")){//when the left mouse button is pressed
			FireBullet();//look for and use the fire bullet operation
		}
	}

	public void FireBullet(){
		//Clone of the bullet
		GameObject bulletClone;

		bulletClone = Instantiate(bulletPrefab, transform.position+1*transform.forward, transform.rotation) as GameObject;

		//add force to the spawned objected
		bulletClone.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletForce);
		//TODO block firing until reloaded
	}







}