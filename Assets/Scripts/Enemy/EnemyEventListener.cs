using UnityEngine;
using System.Collections;


//TODO rename to HitEventListener?
public class EnemyEventListener : MonoBehaviour {

	private EnemyMovement enemyMovement;
	private Animator animator;
	private ExplosionParticleManager explosionParticleManager;

	public void Awake(){
		enemyMovement = GetComponent<EnemyMovement> ();
		animator = GetComponent<Animator> ();

        // TODO bad design. This listener is used in scene without this manager
        GameObject _explosionParticleManager = GameObject.Find(NameContainer.EXPLOSION_PARTICLE_MANAGER);
        if(null != _explosionParticleManager)
        {
            explosionParticleManager = _explosionParticleManager.GetComponent<ExplosionParticleManager>();
        }
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
            EventManager.Instance.PostNotification(new GameEvent(EVENT_TYPE.BULLET_HITS_ENEMY, gameObject.GetComponent<Enemy>()));
        }
	}

	private void EnemyHitByPlayer(){
		animator.SetTrigger (AnimationParamContainer.ENEMY_HIT);
		CreateBloodyParticleSystem ();

		DisableAndDestroy ();
	}

	private void EnemyHit(){
		DisconnectBodyPart (transform.Find ("Head").gameObject);

		CreateBloodyParticleSystem ();

		animator.SetTrigger (AnimationParamContainer.ENEMY_HIT);

		DisableAndDestroy ();
	}

	private void CreateBloodyParticleSystem(){
		explosionParticleManager.setColor (new Color (1, 0, 0, 1));
		explosionParticleManager.createExplosionParticleSystem (transform);
	}

	private void DisableAndDestroy()
    {
		enemyMovement.enabled = false;
		GetComponent<BoxCollider2D> ().enabled = false ;
		GetComponent<CircleCollider2D> ().enabled = false ;

		StartCoroutine(DestroyObject(gameObject));
	}

	private void DisconnectBodyPart(GameObject _gameObject){

        Rigidbody2D _rigidBody = _gameObject.AddComponent<Rigidbody2D> ();
        _rigidBody.mass = 1;
        _rigidBody.gravityScale = 1;

        // Make sure that new rigidbody is not affected by parent rigidbody
        _gameObject.transform.parent = null;
        

		float x = Random.Range (0, 100) + _gameObject.transform.position.x;
		float y = Random.Range (0, 100) + _gameObject.transform.position.y;
		Vector2 direction = new Vector2 (x, y).normalized * 500;

        _rigidBody.AddRelativeForce (direction);
        _rigidBody.AddTorque (500);

        StartCoroutine(DestroyObject(_gameObject));
    }

	IEnumerator DestroyObject(GameObject _gameObject){
		yield return new WaitForSeconds (2);
		Destroy (_gameObject);
	}

	IEnumerator IncreaseDrag(Rigidbody2D _rigidBody){
		for (float d = 0; d <= 10; d++) {
			_rigidBody.drag += d;
			yield return null;
		}
	}
}
