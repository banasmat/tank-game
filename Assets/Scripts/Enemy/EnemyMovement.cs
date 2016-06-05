using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed = 2f;
	public Transform target;
	private float step;


	// Use this for initialization
	void Awake () {
		target = GameObject.FindGameObjectWithTag(TagContainer.PLAYER).transform;
		step = speed * Time.deltaTime;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards (transform.position, target.position, step);
	}
}
