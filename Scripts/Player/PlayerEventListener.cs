using UnityEngine;
using System.Collections;

public class PlayerEventListener : MonoBehaviour {
	
	private PlayerStateManager stateManager;

	void Awake(){
		stateManager = gameObject.GetComponent<PlayerStateManager> ();
	}
		
	void OnCollisionEnter2D(Collision2D coll) {
		// When bullet hits enemy
		if (coll.gameObject.tag == TagContainer.ENEMY_TAG) {
			coll.gameObject.SendMessage("hitByPlayer");
			stateManager.setState (PlayerStateManager.State.Hit);
		}

	}
}
