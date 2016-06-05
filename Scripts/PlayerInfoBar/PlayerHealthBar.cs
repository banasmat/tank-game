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

	private void SetHealthBar (Player playerHealth)
	{
		gameObject.GetComponent<Transform> ().localScale = new Vector3 ((float)playerHealth.health / 100, .2f, 1);
	}
}
