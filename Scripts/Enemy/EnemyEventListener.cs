using UnityEngine;
using System.Collections;


//TODO rename to HitEventListener?
public class EnemyEventListener : MonoBehaviour {

	private EnemyMovement enemyMovement;
	private Animator animator;

	public void Awake(){
		enemyMovement = GetComponent<EnemyMovement> ();
		animator = GetComponent<Animator> ();
	}

	public void OnCollisionEnter2D (Collision2D coll)
	{
		// When enemy hits player
		if (coll.gameObject.tag == TagContainer.PLAYER) {
			
			EnemyHit ();
			EventManager.Instance.PostNotification (new GameEvent(EVENT_TYPE.ENEMY_HITS_PLAYER, gameObject.GetComponent<Enemy>()));
		}

		// When bullet hits enemy
		if (coll.gameObject.tag == TagContainer.BULLET) {
			EnemyHit ();
		}
	}

	public void OnExplosion ()
	{
		animator.SetTrigger (AnimationParamContainer.ENEMY_HIT);
	}

	private void EnemyHit(){
		animator.SetTrigger (AnimationParamContainer.ENEMY_HIT);

		enemyMovement.enabled = false;
		GetComponent<BoxCollider2D> ().enabled = false ;
		GetComponent<CircleCollider2D> ().enabled = false ;

		StartCoroutine(DestroyObject());
	}

	IEnumerator DestroyObject(){
		yield return new WaitForSeconds (3);
		Destroy (gameObject);
	}
}
