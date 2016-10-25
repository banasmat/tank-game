using UnityEngine;
using System.Collections;

public class FireAmmunition : MonoBehaviour {

	public GameObject bulletPrefab;
	private Rigidbody2D bulletPrefabRigidBody;

    private Transform playerTransform;

	private int bulletForce = 500;
	private float reloadTimeInFrames = 25;
	private float maxPressTime = 1.5f;

	private ObjectPoolManager objectPoolManager;
	private InfoBar reloadBar;
	private InfoBar fireForceBar;

	private float downTime, upTime, pressTime = 0;

	private bool isReloading = false;

	public void Awake(){

        playerTransform = GameObject.Find(NameContainer.PLAYER).transform;

        GameObject _fireForceBar = GameObject.Find(NameContainer.FIRE_FORCE_BAR);

        if(null != _fireForceBar)
        {
            fireForceBar = _fireForceBar.GetComponent<InfoBar>();
        }

		bulletPrefabRigidBody = bulletPrefab.GetComponent<Rigidbody2D> ();
	}

	public void Update(){
		// Fire bullet with force depending on how long the key was pressed
		if (Input.GetKeyDown(KeyCode.LeftControl) || Input.touchCount > 0) //TODO create a button on screen?
        {
			if(false == isReloading){
				downTime = Time.time;
            }
		}

		// Release key, fire bullet
		if (Input.GetKeyUp (KeyCode.LeftControl) || pressTime >= maxPressTime || (Input.touchCount > 0 && Input.GetTouch(0).phase.Equals(TouchPhase.Ended))) {

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

	public void FireBullet(float _force, bool reload = true){
		//Clone of the bullet
		GameObject bulletClone;

		bulletClone = Instantiate(bulletPrefab, transform.position+1*transform.forward, transform.rotation) as GameObject;
		bulletClone.GetComponent<Rigidbody2D>().AddForce(transform.right * _force * bulletForce);

        if (reload)
        {
		    StartCoroutine (Reload ());
        }
	}


	IEnumerator Reload(){
        // It has to be done with frames becasue WaintForSeconds can't be called more often than once per frame

        isReloading = true;
        float lastTime = Time.time;
        float multiplier = 100 / reloadTimeInFrames;
        
        for (int i = 0; i <= reloadTimeInFrames; i+= 1) {

            //reloadBar.SetBarValue (i * multiplier);

            yield return new WaitForFixedUpdate();
			
        }

        isReloading = false;

    }

}