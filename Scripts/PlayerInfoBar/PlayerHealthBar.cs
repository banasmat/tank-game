using UnityEngine;
using System.Collections;

//TODO rename to EventListener?
public class PlayerHealthBar : MonoBehaviour, IListener {

	void Start ()
	{
		//Add myself as listener for health change events
		EventManager.Instance.AddListener (EVENT_TYPE.HEALTH_CHANGE, this);
	}
		
	public void OnEvent (IEvent Event)
	{
		switch (Event.GetEventType()) {
		case EVENT_TYPE.HEALTH_CHANGE:
			SetHealthBar ((PlayerHealthEvent)Event);
			break;
		}
	}

	private void SetHealthBar(PlayerHealthEvent playerHealthEvent){
		gameObject.GetComponent<Transform> ().localScale = new Vector3 ((float)playerHealthEvent.health / 100, .2f, 1);
	}
}
