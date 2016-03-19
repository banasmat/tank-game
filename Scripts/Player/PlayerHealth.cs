using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int health {
		get{ return _health; }
		set {
			_health = Mathf.Clamp (value, 0, 100);

			if (_health <= 0) {
				EventManager.Instance.PostNotification (new GameEvent (EVENT_TYPE.GAME_OVER));
			}

			EventManager.Instance.PostNotification (new GameEvent(EVENT_TYPE.HEALTH_CHANGE, this));
		}
	}

	private int _health = 100;

}
