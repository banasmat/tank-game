using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class FireButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private FireAmmunition fireAmmunition;


    private InfoBar fireForceBar;
    private float maxPressTime = 1.5f;

    private float downTime, upTime, pressTime = 0;

    void Start () {
        fireAmmunition = GameObject.Find(NameContainer.PLAYER).gameObject.GetComponentInChildren<FireAmmunition>();

        GameObject _fireForceBar = GameObject.Find(NameContainer.FIRE_FORCE_BAR);

        if (null != _fireForceBar)
        {
            fireForceBar = _fireForceBar.GetComponent<InfoBar>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (false == fireAmmunition.IsReloading)
        {
            downTime = Time.time;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (0 != downTime)
        {
            shoot();
        }
    }

    public void Update()
    {
        // Control Info Bar
        if (0 != downTime)
        {
            pressTime = Time.time - downTime;
            fireForceBar.SetBarValue(pressTime * (100 / maxPressTime)); // We're passing percentage

            // Release key, fire bullet
            if (pressTime >= maxPressTime)
            {
                shoot();
            }
        }

    }

    private void shoot()
    {
        fireAmmunition.FireBullet(Mathf.Clamp(pressTime, 1, 500));


        fireForceBar.SetBarValue(0);

        downTime = 0;
        pressTime = 0;
    }
    
}
