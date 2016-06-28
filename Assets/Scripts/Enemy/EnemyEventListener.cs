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

	private void EnemyHit(){
		animator.SetTrigger (AnimationParamContainer.ENEMY_HIT);

		enemyMovement.enabled = false;
		GetComponent<BoxCollider2D> ().enabled = false ;
		GetComponent<CircleCollider2D> ().enabled = false ;

		makeLimbFly (transform.Find ("Head").gameObject);
		makeLimbFly (transform.Find ("RightHandPivot").gameObject);
		makeLimbFly (transform.Find ("LeftLegPivot").gameObject);

		StartCoroutine(DestroyObject());
	}

	private void makeLimbFly(GameObject _gameObject){
		//TODO maybe it's better to ADD rigidbody programatically
		Rigidbody2D _rigidBody = _gameObject.AddComponent<Rigidbody2D> ();
		//_rigidBody.mass = 1f;
		//_rigidBody.gravityScale = 1f;
		//_rigidBody.angularDrag = 0.05f;

		float x = Random.Range (-1f, 1f) + _gameObject.transform.position.x;
		float y = Random.Range (-1f, 1f) + _gameObject.transform.position.y;
		Vector2 direction = new Vector2 (x, y).normalized * 500;
		_rigidBody.AddRelativeForce (direction);
	}

	IEnumerator DestroyObject(){
		yield return new WaitForSeconds (4);
		Destroy (gameObject);
	}
}
