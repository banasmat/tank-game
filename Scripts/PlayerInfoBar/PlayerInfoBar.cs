using UnityEngine;
using System.Collections;

public class PlayerInfoBar : MonoBehaviour {

	private Vector2 position;

	private float camHeight;
	private float camWidth;

	private Transform transformComponent;

	public void Awake(){
		transformComponent = GetComponent<Transform> ();

		//TODO this should be in some static utils
		camHeight = Camera.main.orthographicSize * 1f;
		camWidth = camHeight * Camera.main.aspect;
	}

	// Update is called once per frame
	void FixedUpdate () {
		position = new Vector2(Camera.main.transform.position.x - camWidth/2 + transformComponent.localScale.x, camHeight - transformComponent.localScale.y);
		transformComponent.position = position;
	}
}
