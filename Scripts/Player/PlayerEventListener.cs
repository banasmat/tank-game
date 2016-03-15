using UnityEngine;
using System.Collections;

public class PlayerEventListener : MonoBehaviour, IListener
{
	
	private PlayerStateManager stateManager;
		
	void Awake ()
	{
		stateManager = gameObject.GetComponent<PlayerStateManager> ();
	}

	void Start ()
	{
		//Add myself as listener for health change events
		EventManager.Instance.AddListener (EVENT_TYPE.HEALTH_CHANGE, this);
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		// When bullet hits enemy
		if (coll.gameObject.tag == TagContainer.ENEMY_TAG) {
			coll.gameObject.SendMessage ("hitByPlayer");
			stateManager.setState (PlayerStateManager.State.Hit);
		}
	}

	public void OnEvent (IEvent Event)
	{
		switch (Event.GetEventType()) {
		case EVENT_TYPE.HEALTH_CHANGE:
			//OnHealthChange (Sender, (int)Param);
			break;
		}
	}
}
