using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float Speed = 2f;
	public Transform target;
	private float step;


	// Use this for initialization
	void Awake () {
		target = GameObject.FindGameObjectWithTag(TagContainer.PLAYER).transform;
		step = Speed * Time.deltaTime;

	}
	
	// Update is called once per frame
	void Update () {

        if(false == GamePlayManager.Instance.Paused)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }

	}
}
