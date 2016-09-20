using UnityEngine;
using System.Collections;

//-----------------------------------------------------------
//Enum defining all possible game events
//More events should be added to the list
public enum EVENT_TYPE
{
	BULLET_EXPLOSION,
	ENEMY_HITS_PLAYER,
    BULLET_HITS_ENEMY, //TODO maybe this should contain bullet and enemy object
	HEALTH_CHANGE,
	GAME_OVER
}


public class GameEvent {

	public EVENT_TYPE eventType;
	public Component component;

	public GameEvent(EVENT_TYPE _eventType, Component _component = null){
		eventType = _eventType;
		component = _component;
	}
}
