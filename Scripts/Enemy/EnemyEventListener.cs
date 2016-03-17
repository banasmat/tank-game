using UnityEngine;
using System.Collections;


//TODO rename to HitEventListener?
public class EnemyEventListener : MonoBehaviour {

	private EnemyStateManager stateManager;

	public void Awake(){
		stateManager = gameObject.GetComponent<EnemyStateManager> ();
	}

	public void OnCollisionEnter2D (Collision2D coll)
	{
		// When player hits enemy
		if (coll.gameObject.tag == TagContainer.PLAYER_TAG) {
			hitByPlayer ();
			EventManager.Instance.PostNotification (new GameEvent(EVENT_TYPE.ENEMY_HITS_PLAYER, gameObject.GetComponent<EnemyStrength>()));
		}
	}

	private void hitByBullet(){
		//TODO change enemy state to change the animation, then destroy object
		stateManager.setState(EnemyStateManager.State.Hit);
	}

	private void hitByPlayer(){
		//TODO change enemy state to change the animation, then destroy object
		stateManager.setState(EnemyStateManager.State.Hit);
	}
}
