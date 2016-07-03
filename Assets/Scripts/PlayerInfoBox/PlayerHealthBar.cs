using UnityEngine;
using System.Collections;

//TODO rename to PlayerInfoBarEventListener?
public class PlayerHealthBar : InfoBar, IListener
{
	void Start ()
	{
		EventManager.Instance.AddListener (EVENT_TYPE.HEALTH_CHANGE, this);
	}

	public void OnEvent (GameEvent GameEvent)
	{
		//TODO maybe control from Player.Health and remove all inheriting from InfoBar
		switch (GameEvent.eventType) {	
		case EVENT_TYPE.HEALTH_CHANGE:
			Player player = (Player)GameEvent.component;
			SetBarValue (player.health);
			break;
		}
	}

}
