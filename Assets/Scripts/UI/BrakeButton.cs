using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

//TODO rename to SpeedButton (if we keep this change)
public class BrakeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private PlayerMovement playerMovement;
    private InfoBar breakBar; // TODO decouple info bar

    private float downTime, pressTime = 0;
    private float maxPressTime = 10;

    // Use this for initialization
    public void Start () {

        playerMovement = GameObject.Find(NameContainer.PLAYER).GetComponentInChildren<PlayerMovement>();

        GameObject _breakBar = GameObject.Find(NameContainer.BREAK_BAR);
        // TODO this is to avoid null reference errors. Probably scene objects should be retrieved by one separate object that would provide some proxies in case elements are not on stage?
        if (null != _breakBar)
        {
            breakBar = _breakBar.GetComponent<InfoBar>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (false == playerMovement.IsSpeedingUp)
        {
            playerMovement.IsSpeedingUp = true;

            downTime = Time.time;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        stopSpeedingUp();
    }

    // Update is called once per frame
    public void Update () {

        if (downTime > 0)
        {
            // Control Info Bar
            pressTime = Time.time - downTime;
            breakBar.SetBarValue(pressTime * (100 / maxPressTime)); // We're passing percentage

            if (pressTime >= maxPressTime)
            {
                stopSpeedingUp();
            }
        }
    }

    private void stopSpeedingUp()
    {
        playerMovement.IsSpeedingUp = false;

        breakBar.SetBarValue(0);

        downTime = 0;
        pressTime = 0;
    }
}
