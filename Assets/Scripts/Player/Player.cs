using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Sprite stainedTankBody;

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
	private bool stainsApplied = false;

	//TODO probably will have to do it incrementaly
	public void ApplyStains(){

		if (false == stainsApplied) {
			GameObject tankBody = transform.Find ("TankBody").gameObject;

			tankBody.GetComponent<SpriteRenderer> ().sprite = stainedTankBody;

			stainsApplied = true;
		}
	}

}
