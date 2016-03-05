using UnityEngine;
using System.Collections;

//TODO rename to HitEventListener?
public class EnemyEventListener : MonoBehaviour {

	void hitByBullet(){
		//TODO change enemy state to change the animation, then destroy object
		Debug.Log ("hit");
	}
}
