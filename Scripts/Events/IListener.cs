using UnityEngine;
using System.Collections;

//-----------------------------------------------------------
//Listener interface to be implemented on Listener classes
public interface IListener
{
	//Notification function invoked when events happen
	void OnEvent (IEvent Event);
}
//-----------------------------------------------------------