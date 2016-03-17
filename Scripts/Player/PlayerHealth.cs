using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int health {
		get{ return _health; }
		set {
			// If health is lowered
			if (_health > value) {
				healthLowered ();
			}

			if (_health < value) {
				healthIncreased ();
			}

			//Clamp health between 0-100
			_health = Mathf.Clamp (value, 0, 100);
			//Post notification - health has been changed

			if (_health <= 0) {
				healthZero ();
			}

			EventManager.Instance.PostNotification (new GameEvent(EVENT_TYPE.HEALTH_CHANGE, this));
		}
	}

	private int _health = 100;
	private Animator animator;

	public void Awake(){
		animator = GetComponent<Animator>();
	}


	private void healthLowered (){
		animator.SetTrigger (AnimationParamContainer.PLAYER_HIT);
	}

	private void healthIncreased (){
		// TODO to be implemented
	}

	private void healthZero (){
		animator.SetBool (AnimationParamContainer.PLAYER_DEAD, true);
	}
}
