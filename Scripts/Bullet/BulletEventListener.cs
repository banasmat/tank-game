using UnityEngine;
using System.Collections;

//TODO rename to BulletEventListener
public class BulletEventListener : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
		// When bullet hits enemy
		if (coll.gameObject.tag == TagContainer.ENEMY_TAG) {
			coll.gameObject.SendMessage("hitByBullet");
			gameObject.SendMessage("setState", BulletStateManager.State.Hit);
		}

		if (coll.gameObject.tag == TagContainer.GROUND_TAG) {
			gameObject.SendMessage("setState", BulletStateManager.State.Hit);
		}
			

	}
}