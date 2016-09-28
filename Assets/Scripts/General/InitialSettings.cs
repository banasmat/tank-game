using UnityEngine;
using System.Collections;

public class InitialSettings : MonoBehaviour {
    
	void Start () {
        // Force horizontal orientation
        Screen.orientation = ScreenOrientation.Landscape;
    }
}
