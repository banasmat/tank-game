using UnityEngine;
using System.Collections;

public class PlayerEventListener : MonoBehaviour {
	
	private PlayerStateManager stateManager;

	void Awake(){
		stateManager = gameObject.GetComponent<PlayerStateManager> ();
	}
	

}
