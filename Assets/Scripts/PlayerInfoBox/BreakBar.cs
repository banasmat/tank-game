using UnityEngine;
using System.Collections;
//TODO reorganize inheritance, change names to e.g. PowerLoadBar etc...
public class BreakBar : InfoBar {

	public void Start(){
		transform.localScale = new Vector3 (0, 0);
	}
}
