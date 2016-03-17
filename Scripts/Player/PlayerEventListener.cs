using UnityEngine;
using System.Collections;

public class PlayerEventListener : MonoBehaviour, IListener
{
	private PlayerHealth playerHealth;
	private Animator animator;
		
	void Awake ()
	{
		playerHealth = gameObject.GetComponent<PlayerHealth> ();
		animator = GetComponent<Animator>();
	}

	void Start ()
	{
		EventManager.Instance.AddListener (EVENT_TYPE.ENEMY_HITS_PLAYER, this);
	}


	public void OnEvent (GameEvent gameEvent)
	{
		switch (gameEvent.eventType) {
		case EVENT_TYPE.ENEMY_HITS_PLAYER:
			hitByEnemy ((EnemyStrength)gameEvent.component);
			break;
		}
	}

	private void hitByEnemy (EnemyStrength enemyStrength){
		playerHealth.health -= enemyStrength.strength;

		Debug.Log (enemyStrength.strength);

		//TODO move it to playerHealth script?
		animator.SetTrigger (AnimationParamContainer.PLAYER_HIT);
	}
}
