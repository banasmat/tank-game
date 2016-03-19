using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed = 2f;
	public Transform target;
	private float step;


	// Use this for initialization
	void Awake () {

		//Wait with execution for the call from EnemyStateManager
		enabled = false;

		target = GameObject.FindGameObjectWithTag("Player").transform;
		step = speed * Time.deltaTime;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards (transform.position, target.position, step);
	}
}
