using UnityEngine;
using System.Collections;

//TODO rename to PlayerInfoBarEventListener?
public class PlayerHealthBar : MonoBehaviour, IListener
{
	void Start ()
	{
		EventManager.Instance.AddListener (EVENT_TYPE.HEALTH_CHANGE, this);
	}

	public void OnEvent (GameEvent GameEvent)
	{
		switch (GameEvent.eventType) {
		case EVENT_TYPE.HEALTH_CHANGE:
			SetHealthBar ((Player)GameEvent.component);
			break;
		}
	}

	//TODO should be smooth (Update, LERP)?
	private void SetHealthBar (Player playerHealth)
	{
		transform.localScale = new Vector3 ((float)playerHealth.health / 100, transform.localScale.y);
	}
}
