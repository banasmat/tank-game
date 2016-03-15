using UnityEngine;
using System.Collections;

public class PlayerHealthEvent : IEvent {

	public int health;

	public PlayerHealthEvent(int _health){
		health = _health;
	}

	public EVENT_TYPE GetEventType(){
		return EVENT_TYPE.HEALTH_CHANGE;
	}
}
