using UnityEngine;
using System.Collections;

public class FireAmmunition : MonoBehaviour {

	public GameObject bulletPrefab;
	private Rigidbody2D bulletPrefabRigidBody;

    private Transform playerTransform;

	private int bulletForce = 500;
	private float reloadTimeInFrames = 25;


	private ObjectPoolManager objectPoolManager;
	private InfoBar reloadBar;


	public bool IsReloading = false;

	public void Awake(){

        playerTransform = GameObject.Find(NameContainer.PLAYER).transform;
		bulletPrefabRigidBody = bulletPrefab.GetComponent<Rigidbody2D> ();
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

        IsReloading = true;
        float lastTime = Time.time;
        float multiplier = 100 / reloadTimeInFrames;
        
        for (int i = 0; i <= reloadTimeInFrames; i+= 1) {

            //reloadBar.SetBarValue (i * multiplier);

            yield return new WaitForFixedUpdate();
			
        }

        IsReloading = false;

    }

}