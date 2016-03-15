using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int Health {
		get{ return _health; }
		set {
			//Clamp health between 0-100
			_health = Mathf.Clamp (value, 0, 100);
			//Post notification - health has been changed
			EventManager.Instance.PostNotification (new PlayerHealthEvent(_health));
		}
	}

	private int _health = 100;
}
