using UnityEngine;
using System.Collections;

public class PlayerInfoBox : MonoBehaviour {

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

	void Update () {
		transformComponent.position = new Vector2(Camera.main.transform.position.x - camWidth/2, camHeight - transformComponent.localScale.y);
	}
}
