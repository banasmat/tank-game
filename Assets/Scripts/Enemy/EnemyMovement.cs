using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float Speed = 2f;
	public Transform target;
	private float step;


	// Use this for initialization
	void Awake () {
		target = GameObject.FindGameObjectWithTag(TagContainer.PLAYER).transform;
	}
	
	// Update is called once per frame
	void Update () {

        if(false == GamePlayManager.Instance.Paused)
        {
            step = Speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }

	}
}
