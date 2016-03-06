using UnityEngine;
using System.Collections;


//TODO rename to HitEventListener?
public class EnemyEventListener : MonoBehaviour {

	private EnemyStateManager stateManager;

	void Awake(){
		stateManager = gameObject.GetComponent<EnemyStateManager> ();
	}

	void hitByBullet(){
		//TODO change enemy state to change the animation, then destroy object
		stateManager.setState(EnemyStateManager.State.Hit);
	}
}
