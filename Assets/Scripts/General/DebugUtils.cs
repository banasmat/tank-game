using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DebugUtils : MonoBehaviour
{

	public GameObject particle;
	void Update() {
		if (Input.GetButtonDown("Fire1")) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray))
			//	Instantiate(particle, transform.position, transform.rotation);

			Debug.Log ("Mouse clicked at: " + transform.position);
		}
	}
}

