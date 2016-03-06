using UnityEngine;
using System.Collections;

//TODO rename to BulletEventListener
public class BulletEventListener : MonoBehaviour {

	private BulletStateManager stateManager;

	void Awake(){
		stateManager = gameObject.GetComponent<BulletStateManager> ();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		// When bullet hits enemy
		if (coll.gameObject.tag == TagContainer.ENEMY_TAG) {
			coll.gameObject.SendMessage("hitByBullet");
			stateManager.setState (BulletStateManager.State.Hit);
		}

		if (coll.gameObject.tag == TagContainer.GROUND_TAG) {
			stateManager.setState (BulletStateManager.State.Hit);
		}
	}
}