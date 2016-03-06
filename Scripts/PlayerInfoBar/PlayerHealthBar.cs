using UnityEngine;
using System.Collections;

//TODO rename to EventListener?
public class PlayerHealthBar : MonoBehaviour {
	
	void ReduceHealth(float amount){
		gameObject.GetComponent<Transform> ().localScale -= new Vector3 (amount / 100, 0, 0);
	}
}
