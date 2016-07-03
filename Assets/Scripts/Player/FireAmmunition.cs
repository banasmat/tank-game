using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireAmmunition : MonoBehaviour {

	public GameObject bulletPrefab;
	private Rigidbody2D bulletPrefabRigidBody;

	public float maxPressTime = 2;

	public int bulletForce = 200;
	public int reloadTime = 2;

	private ObjectPoolManager objectPoolManager;
	private ReloadBar reloadBar;
	private FireForceBar fireForceBar;

	private float downTime, pressTime = 0;

	private bool isReloading = false;

	public void Awake(){
		//TODO at the moment we're not using object pool here. Probably remove.
		objectPoolManager = GameObject.Find(NameContainer.OBJECT_POOL_MANAGER).GetComponent<ObjectPoolManager>();
		objectPoolManager.CreatePool (bulletPrefab, 10);

		reloadBar = GameObject.Find(NameContainer.RELOAD_BAR).GetComponent<ReloadBar>();
		fireForceBar = GameObject.Find(NameContainer.FIRE_FORCE_BAR).GetComponent<FireForceBar>();

		bulletPrefabRigidBody = bulletPrefab.GetComponent<Rigidbody2D> ();
	}

	public void Update(){
		// Fire bullet with force depending on how long the key was pressed
		if (Input.GetKeyDown(KeyCode.LeftControl)){//when the left mouse button is pressed
			Debug.Log ("Fire key pressed");
			if(false == isReloading){
				downTime = Time.time;
			}
		}
		// Release key, fire bullet
		if (Input.GetKeyUp (KeyCode.LeftControl) || pressTime >= maxPressTime) {

			if(0 != downTime){
				FireBullet(pressTime);

				fireForceBar.SetBarValue (0);

				downTime = 0;
				pressTime = 0;
			}
		}
	}

	public void FixedUpdate () {

		// Control Info Bar
		if (downTime != 0) {
			pressTime = Time.time - downTime;
			fireForceBar.SetBarValue (pressTime * (100/maxPressTime)); // We're passing percentage
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

			reloadBar.SetBarValue (i);

			yield return new WaitForFixedUpdate();
		}





	}




}