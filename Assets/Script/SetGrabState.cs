using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGrabState : MonoBehaviour {


	public void SetGrab()
	{
		if (GlobalVariable.MODE == "Grab_On"){
			GlobalVariable.MODE = "Grab_Off";
		}
		else
		{
			GlobalVariable.MODE = "Grab_On";
		}
	}
}
