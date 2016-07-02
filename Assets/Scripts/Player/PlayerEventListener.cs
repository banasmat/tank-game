using UnityEngine;
using System.Collections;

public class PlayerEventListener : MonoBehaviour, IListener
{
	private Player player;
	private PlayerMovement playerMovement;
	private FireAmmunition fireAmmunition;
	private Animator animator;

		
	void Awake ()
	{
		player = gameObject.GetComponent<Player> ();
		playerMovement = gameObject.GetComponent<PlayerMovement> ();
		fireAmmunition = gameObject.GetComponentInChildren<FireAmmunition> ();
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
			HitByEnemy ((Enemy)gameEvent.component);
			break;
		case EVENT_TYPE.GAME_OVER:
			GameOver ();
			break;
		}
	}

	private void HitByEnemy (Enemy enemy){
		player.health -= enemy.strength;

		player.ApplyStains ();
	}

	private void GameOver(){
		playerMovement.enabled = false;
		fireAmmunition.enabled = false;

		animator.SetBool (AnimationParamContainer.PLAYER_DEAD, true);
	}

	IEnumerator HaltPlayer(){
		yield return new WaitForSeconds (1);
		playerMovement.enabled = true;
	}
}
