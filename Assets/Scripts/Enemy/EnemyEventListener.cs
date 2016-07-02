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
			
			EnemyHitByPlayer ();
			EventManager.Instance.PostNotification (new GameEvent(EVENT_TYPE.ENEMY_HITS_PLAYER, gameObject.GetComponent<Enemy>()));
		}

		// When bullet hits enemy
		if (coll.gameObject.tag == TagContainer.BULLET) {
			EnemyHit ();
		}
	}

	private void EnemyHitByPlayer(){
		animator.SetTrigger (AnimationParamContainer.ENEMY_HIT);
		DisableAndDestroy ();
	}

	private void EnemyHit(){

		DisableAndDestroy ();

		//animator.SetTrigger (AnimationParamContainer.ENEMY_HIT);

		DisconnectBodyPart (transform.Find ("Head").gameObject);
		//DisconnectBodyPart (transform.Find ("RightHandPivot").gameObject);
		//DisconnectBodyPart (transform.Find ("LeftLegPivot").gameObject);
	}

	private void DisableAndDestroy(){
		enemyMovement.enabled = false;
		GetComponent<BoxCollider2D> ().enabled = false ;
		GetComponent<CircleCollider2D> ().enabled = false ;

		StartCoroutine(DestroyObject());
	}

	private void DisconnectBodyPart(GameObject _gameObject){
		//TODO maybe it's better to ADD rigidbody programatically
		Rigidbody2D _rigidBody = _gameObject.AddComponent<Rigidbody2D> ();
		//Collider2D _collider2D = _gameObject.AddComponent<BoxCollider2D> ();

		_rigidBody.mass = 0.5f;
		_rigidBody.gravityScale = 0.5f;
		//_rigidBody.velocity = new Vector2(0,0);
		//_rigidBody.angularVelocity = 0;
		//_rigidBody.isKinematic = true;
		//StartCoroutine(IncreaseDrag(_rigidBody));

		float x = Random.Range (-1f, 1f) + _gameObject.transform.position.x;
		float y = Random.Range (-1f, 1f) + _gameObject.transform.position.y + 10;
		Vector2 direction = new Vector2 (x, y).normalized * 250;
		_rigidBody.AddRelativeForce (direction);
		_rigidBody.AddTorque (5);

	}

	IEnumerator DestroyObject(){
		yield return new WaitForSeconds (2);
		Destroy (gameObject);
	}

	IEnumerator IncreaseDrag(Rigidbody2D _rigidBody){
		for (float d = 0; d <= 10; d++) {
			_rigidBody.drag += d;
			yield return null;
		}
	}
}
