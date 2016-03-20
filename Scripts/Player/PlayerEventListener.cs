using UnityEngine;
using System.Collections;

public class PlayerEventListener : MonoBehaviour, IListener
{
	private PlayerHealth playerHealth;
	private PlayerMovement playerMovement;
	private FireAmmunition fireAmmunition;
	private Animator animator;

		
	void Awake ()
	{
		playerHealth = gameObject.GetComponent<PlayerHealth> ();
		playerMovement = gameObject.GetComponent<PlayerMovement> ();
		fireAmmunition = gameObject.GetComponent<FireAmmunition> ();
		animator = GetComponent<Animator>();
	}

	void Start ()
	{
		EventManager.Instance.AddListener (EVENT_TYPE.ENEMY_HITS_PLAYER, this);
		EventManager.Instance.AddListener (EVENT_TYPE.GAME_OVER, this);
	}


	public void OnEvent (GameEvent gameEvent)
	{
		switch (gameEvent.eventType) {
		case EVENT_TYPE.ENEMY_HITS_PLAYER:
			HitByEnemy ((EnemyStrength)gameEvent.component);
			break;
		case EVENT_TYPE.GAME_OVER:
			GameOver ();
			break;
		}
	}

	private void HitByEnemy (EnemyStrength enemyStrength){
		playerHealth.health -= enemyStrength.strength;

		Debug.Log("player hit");
		animator.SetTrigger (AnimationParamContainer.PLAYER_HIT);
	}

	private void GameOver(){
		playerMovement.enabled = false;
		fireAmmunition.enabled = false;

		animator.SetBool (AnimationParamContainer.PLAYER_DEAD, true);
	}
}
