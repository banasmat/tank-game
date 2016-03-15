using UnityEngine;
using System.Collections;

//-----------------------------------------------------------
//Enum defining all possible game events
//More events should be added to the list
public enum EVENT_TYPE
{
	GAME_INIT,
	GAME_END,
	AMMO_EMPTY,
	HEALTH_CHANGE,
	DEAD}
;

public interface IEvent {

	EVENT_TYPE GetEventType();
}
