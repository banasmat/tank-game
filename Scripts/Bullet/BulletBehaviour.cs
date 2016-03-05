using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

	void Start () {
	}


	void OnCollisionEnter2D(Collision2D coll) {
		// When bullet hits enemy
		Debug.Log (coll.gameObject.tag);
		if (coll.gameObject.tag == "Enemy") {
			
			coll.gameObject.SendMessage("hitByBullet");
			//TODO start explosion animation
			//TODO destroy this object
		}
			

	}
}