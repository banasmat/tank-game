using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed = 2f;
	public Transform target;


	// Use this for initialization
	void Start () {
		//TODO this shouldn't be coupled?
		//TODO move "Player" to constant
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector2.MoveTowards (transform.position, target.position, step);
	}
}
