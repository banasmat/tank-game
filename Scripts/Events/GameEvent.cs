using UnityEngine;
using System.Collections;

//-----------------------------------------------------------
//Enum defining all possible game events
//More events should be added to the list
public enum EVENT_TYPE
{
	ENEMY_HITS_PLAYER,
	HEALTH_CHANGE,
}


public class GameEvent {

	public EVENT_TYPE eventType;
	public Component component;

	public GameEvent(EVENT_TYPE _eventType, Component _component){
		eventType = _eventType;
		component = _component;
	}
}
