using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireAmmunition : MonoBehaviour {

	public GameObject bulletPrefab;
	private Rigidbody2D bulletPrefabRigidBody;

	public int bulletForce = 800;
	public int reloadTime = 2;

	private ObjectPoolManager objectPoolManager;
	private ReloadBar reloadBar;

	private bool isReloading = false;

	void Awake(){
		//TODO at the moment we're not using object pool here. Probably remove.
		objectPoolManager = GameObject.Find(NameContainer.OBJECT_POOL_MANAGER).GetComponent<ObjectPoolManager>();
		objectPoolManager.CreatePool (bulletPrefab, 10);

		reloadBar = GameObject.Find(NameContainer.RELOAD_BAR).GetComponent<ReloadBar>();

		bulletPrefabRigidBody = bulletPrefab.GetComponent<Rigidbody2D> ();
	}

	void Update () {

		if (Input.GetButtonDown("Fire1")){//when the left mouse button is pressed

			if(false == isReloading){
				FireBullet();//look for and use the fire bullet operation
			}
		}
	}

	public void FireBullet(){
		//Clone of the bullet
		GameObject bulletClone;

		bulletClone = Instantiate(bulletPrefab, transform.position+1*transform.forward, transform.rotation) as GameObject;
		bulletClone.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletForce);


		StartCoroutine (Reload ());
	}


	IEnumerator Reload(){
		//TODO Reload time

		for (int i = 0; i <= 100; i+= 1) {

			if (i == 0) {
				isReloading = true;
			}

			if (i == 100) {
				isReloading = false;
			}

			reloadBar.SetBar (i);

			yield return new WaitForFixedUpdate();
		}





	}




}