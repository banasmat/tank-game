using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireAmmunition : MonoBehaviour {

	public GameObject bulletPrefab;
	private Rigidbody2D bulletPrefabRigidBody;

	private int bulletForce = 500;
	private float reloadTimeInFrames = 25;
	private float maxPressTime = 1.5f;

	private ObjectPoolManager objectPoolManager;
	private InfoBar reloadBar;
	private InfoBar fireForceBar;

	private float downTime, pressTime = 0;

	private bool isReloading = false;

	public void Awake(){
		//TODO at the moment we're not using object pool here. Probably remove.
		objectPoolManager = GameObject.Find(NameContainer.OBJECT_POOL_MANAGER).GetComponent<ObjectPoolManager>();
		objectPoolManager.CreatePool (bulletPrefab, 10);

		reloadBar = GameObject.Find(NameContainer.RELOAD_BAR).GetComponent<InfoBar>();
		fireForceBar = GameObject.Find(NameContainer.FIRE_FORCE_BAR).GetComponent<InfoBar>();

		bulletPrefabRigidBody = bulletPrefab.GetComponent<Rigidbody2D> ();
	}

	public void Update(){
		// Fire bullet with force depending on how long the key was pressed
		if (Input.GetKeyDown(KeyCode.LeftControl)){//when the left mouse button is pressed
			if(false == isReloading){
				downTime = Time.time;
			}
		}
		// Release key, fire bullet
		if (Input.GetKeyUp (KeyCode.LeftControl) || pressTime >= maxPressTime) {

			if(0 != downTime){
				FireBullet(Mathf.Clamp(pressTime, 1, 500));

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
        // It has to be done with frames becasue WaintForSeconds can't be called more often than once per frame

        isReloading = true;
        float lastTime = Time.time;
        float multiplier = 100 / reloadTimeInFrames;
        
        for (int i = 0; i <= reloadTimeInFrames; i+= 1) {

            reloadBar.SetBarValue (i * multiplier);

            yield return new WaitForFixedUpdate();
			
        }

        isReloading = false;

    }

}