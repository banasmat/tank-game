using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Sprite[] stainedTankBody;

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
	private int stainsLvl = 0;

	//TODO refactor
	public void ApplyStains(){

		if (stainsLvl < stainedTankBody.Length) {
			GameObject tankBody = transform.Find (NameContainer.TANK_BODY).gameObject;

			StartCoroutine (SetStainedSprite (tankBody));

		}
	}

	IEnumerator SetStainedSprite(GameObject tankBody){
		yield return new WaitForSeconds (0.25f);
		tankBody.GetComponent<SpriteRenderer> ().sprite = stainedTankBody[stainsLvl];
		stainsLvl ++;
	}

}
