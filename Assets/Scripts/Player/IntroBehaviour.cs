using UnityEngine;
using System.Collections;

public class IntroBehaviour : MonoBehaviour {

    private FireAmmunition fireAmmunition;


    // Use this for initialization
    void OnEnable () {

        fireAmmunition = gameObject.GetComponentInChildren<FireAmmunition>();

        if (null != fireAmmunition)
        {
            InvokeRepeating("shoot", 3, 2);
        }
    }
	
    public void shoot()
    {
        if (fireAmmunition.gameObject.activeInHierarchy)
        {
            fireAmmunition.FireBullet(3, false);
        }
    }
}
