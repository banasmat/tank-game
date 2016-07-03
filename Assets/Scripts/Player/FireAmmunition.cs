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

	private float downTime, upTime, pressTime = 0;

	private bool isReloading = false;

	void Awake(){
		//TODO at the moment we're not using object pool here. Probably remove.
		objectPoolManager = GameObject.Find(NameContainer.OBJECT_POOL_MANAGER).GetComponent<ObjectPoolManager>();
		objectPoolManager.CreatePool (bulletPrefab, 10);

		reloadBar = GameObject.Find(NameContainer.RELOAD_BAR).GetComponent<ReloadBar>();

		bulletPrefabRigidBody = bulletPrefab.GetComponent<Rigidbody2D> ();
	}

	void Update () {
		// Fire bullet with force depending on how long the key was pressed
		if (Input.GetKeyDown(KeyCode.LeftControl)){//when the left mouse button is pressed
			if(false == isReloading){

				downTime = Time.time;

				//TODO info bar
			}
		}
		if (Input.GetKeyUp (KeyCode.LeftControl)) {

			if(false == isReloading && 0 != downTime){
				upTime = Time.time;
				pressTime = upTime - downTime; 

				FireBullet(pressTime);

				downTime = 0;
			}
		}
	}

	public void FireBullet(float _force){
		//Clone of the bullet
		GameObject bulletClone;

		bulletClone = Instantiate(bulletPrefab, transform.position+1*transform.forward, transform.rotation) as GameObject;
		bulletClone.GetComponent<Rigidbody2D>().AddForce(transform.right * _force * bulletForce);


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